using Dtos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Mini_E_commerce.UI;
using MiniEcommerce.UI.Services;

namespace Mini_E_commerce.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7252") });

            builder.Services.AddScoped<IService<CategoryDto, CategoryCreateDto>, CategoryService>();

            builder.Services.AddScoped<IService<ProductDto, ProductCreateDto>, ProductService>();

            await builder.Build().RunAsync();
        }
    }
}