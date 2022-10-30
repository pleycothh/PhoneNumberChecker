using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Api.Data;
using PhoneNumberChecker.Api.Services;
using PhoneNumberChecker.Api.Services.Contracts;

namespace PhoneNumberChecker.Api
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Inject service
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IDownloadService, DownloadService>();
            builder.Services.AddScoped<IValidationService, ValidationService>();

            // myAllowSpecificOrigins
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            // DbContext
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}