using CoreBusiness;
using UseCases.Interfaces;

namespace PluginsInMemory
{
    public class ProductRepository :IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "Bike Seat", Quantity = 10, Price = 2 },
                new Product { ProductId = 2, ProductName = "Bike Body", Quantity = 10, Price = 15 },
                new Product { ProductId = 3, ProductName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Product { ProductId = 4, ProductName = "Bike Pedels", Quantity = 20, Price = 1 },
            };
        }

        public Task AddProductAsync(Product Product)
        {
            if (_products.Any(x => x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
                {
                    return Task.CompletedTask; 
                }
            
            var maxId = _products.Max(x => x.ProductId);
            Product.ProductId = maxId + 1;
            _products.Add(Product);
            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product Product)
        {
            if (_products.Any(x => x.ProductId != Product.ProductId && x.ProductName.Equals(Product.ProductName,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var ProductToUpdate = _products.FirstOrDefault(x => x.ProductId == Product.ProductId);
            if (ProductToUpdate is null)
                {
                    return Task.CompletedTask;
                }
            ProductToUpdate.ProductName = Product.ProductName;
            ProductToUpdate.Quantity = Product.Quantity;
            ProductToUpdate.Price = Product.Price;
            return Task.CompletedTask;


        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int ProductId)
        {
            return await Task.FromResult(_products.FirstOrDefault(x => x.ProductId == ProductId));
        }

        public Task DeleteProductByIdAsync(int ProductId)
        {
            var ProductToDelete = _products.FirstOrDefault(x => x.ProductId == ProductId);
            if (ProductToDelete is not null)
            {
                _products.Remove(ProductToDelete);
            }
            return Task.CompletedTask;
        }

    }
}
