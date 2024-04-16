using CoachingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CoachingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? connectionString;

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");

                // Use this if we actually take the connectionstring value from a config file, and not our secretly secret secrets!
                //connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")
                //    ?? throw new InvalidOperationException("User secret 'AZURE_SQL_CONNECTIONSTRING' not found.");

                connectionString = builder.Configuration["AZURE_SQL_CONNECTIONSTRING"]
                    ?? throw new InvalidOperationException("User secret 'AZURE_SQL_CONNECTIONSTRING' not found.");
            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING")
                    ?? throw new InvalidOperationException("Connection string 'AZURE_SQL_CONNECTIONSTRING' not found.");
            }

            builder.Services.AddDbContext<PlayersDbContext>(options => options.UseSqlServer(connectionString));
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            app.UseSwagger(options => options.SerializeAsV2 = true);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}