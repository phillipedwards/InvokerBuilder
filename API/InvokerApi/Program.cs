using Data;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace InvokerApi
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.
            builder.Logging.ClearProviders();
            // add logger

            builder.Services.AddDbContext<InvokerSqlRepository>( options =>
            {
                // options.UseSqlServer( builder.Configuration.GetConnectionString( "InvokerSqlRepository" ) );
                options.UseInMemoryDatabase( "InvokerConfiguration" );
            } );    

            builder.Services.AddControllers();
            builder.Services.AddScoped<IInvokerService, InvokerConfigurationService>();
            builder.Services.AddScoped<IInvokerRepository, InvokerSqlRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment() )
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