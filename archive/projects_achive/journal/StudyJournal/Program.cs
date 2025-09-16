using Microsoft.EntityFrameworkCore;
using StudyJournal.Models;
using StudyJournal.Services;
using Microsoft.AspNetCore.Identity;
using StudyJournal.Data;
using StudyJournal.Areas.Identity.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using StudyJournal.Resources;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace StudyJournal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

           // builder.Services.AddDefaultIdentity<StudyJournalUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<StudyJournalContext>();

            builder.Services.AddTransient<ITimeService, SimpleTimeService>();

            //Localization
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                    new CultureInfo("en"),
                    new CultureInfo("ru"),
                    new CultureInfo("ru-RU")
                 };
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            builder.Services.AddSingleton<CommonLocalizationService>();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add services to the container.
            builder.Services.AddRazorPages()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization(options =>
               {
                   options.DataAnnotationLocalizerProvider = (type, factory) =>
                   {
                       var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
                       return factory.Create(nameof(CommonResources), assemblyName.Name);
                   };
               });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.Run();
        }
    }
}
