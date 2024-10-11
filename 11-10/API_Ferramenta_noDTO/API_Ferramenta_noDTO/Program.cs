
using API_Ferramenta_test.Models;
using API_Ferramenta_test.Repos;
using Microsoft.EntityFrameworkCore;

namespace API_Ferramenta_noDTO
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

            builder.Services.AddDbContext<FerramentaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest")  // Configuration indica tutto ciò che si trova nell'appsettings json
                ));

            builder.Services.AddScoped<RepartoRepo>(); // <IRepo<Videoteca> mi da errore, controllare perché
            builder.Services.AddScoped<ProdottoRepo>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
