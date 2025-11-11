using ExampleWebAPI01.Models;
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

            builder.Services.AddControllers();

            string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Web2415-02;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True";

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(ConnectionString));

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            /*
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationContext>();
                
                context.Database.Migrate();
            }
            */

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
