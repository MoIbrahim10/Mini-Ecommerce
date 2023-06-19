
using Microsoft.EntityFrameworkCore;
using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Application.Interfaces.Services;
using Mini_E_commerce.Application.Services;
using Mini_E_commerce.Infrastructure;
using Mini_E_commerce.Infrastructure.Repository;

namespace Mini_E_commerce
{
    public class Program
    {
        private const string CORS_Message = "Messi";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MiniEcommerceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbOffline"));
            });
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(CORS_Message,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(CORS_Message);


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}