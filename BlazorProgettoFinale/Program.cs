using BlazorProgettoFinale.Components;
using PluginsInMemory;
using UseCases.Interfaces;
using UseCases.Inventories;
using UseCases.Inventories.Interfaces;
using UseCases.Products;
using UseCases.Products.Interfaces;

namespace BlazorProgettoFinale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();


            builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
            builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
            builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
            builder.Services.AddTransient<IUpdateInventoryUseCase, UpdateInventoryUseCase>();
            builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
            builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();

            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
            //builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            //builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
            //builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
            builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            

            app.Run();
        }
    }
}
