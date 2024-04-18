using CoachingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CoachingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Fetch connection string from either *top secret* location.
            string? connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")
                ?? throw new InvalidOperationException("Connection string 'AZURE_SQL_CONNECTIONSTRING' not found.");

            builder.Services.AddDbContext<PlayersDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            // Serialize as V2 to comply with Azure App Service.
            app.UseSwagger(options => options.SerializeAsV2 = true);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}