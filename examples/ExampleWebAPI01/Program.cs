using Asp.Versioning;
using ExampleWebAPI01.Models;
using ExampleWebAPI01.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ExampleWebAPI01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationContext2415>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<StandartService>();
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

            builder.Services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "ExampleWebAPI01.xml");

                options.IncludeXmlComments(xmlPath);
                options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Введите JWT токен авторизации.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                      },
                      new List<string>()
                    }
                });
                //options.SwaggerDoc("v1", new OpenApiInfo() { Title = "CodeVersioning", Version = "v1" });
                //options.SwaggerDoc("v2", new OpenApiInfo() { Title = "CodeVersioning", Version = "v2" });

            });            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                   {
                       c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                       c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");                       
                   });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
