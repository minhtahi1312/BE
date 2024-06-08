
using Microsoft.EntityFrameworkCore;
using SWP.CourtBooking.Repository.UnitOfWork;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CourtBookingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDB"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            

            app.Run();
        }
    }
}
