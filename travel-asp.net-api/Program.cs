
using Microsoft.EntityFrameworkCore;

namespace travel_asp.net_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.WithOrigins("https://excursions.bsite.net/")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer("Server=workstation id=excursions.mssql.somee.com;packet size=4096;user id=acos_SQLLogin_1;pwd=3o9n2tzdro;data source=excursions.mssql.somee.com;persist security info=False;initial catalog=excursions;TrustServerCertificate=True;"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}