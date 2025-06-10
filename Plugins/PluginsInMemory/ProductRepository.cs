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

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                {
                    return Task.CompletedTask; 
                }
            
            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductId != product.ProductId && x.ProductName.ToLower() == product.ProductName.ToLower()))
            {
                return Task.CompletedTask;
            }

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productToUpdate is null)
                {
                    return Task.CompletedTask;
                }
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.ProductInventory = product.ProductInventory;
            return Task.CompletedTask;


        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            var newProduct = new Product();
            if (product != null)
            {
                newProduct.ProductId = product.ProductId;
                newProduct.ProductName = product.ProductName;
                newProduct.Price = product.Price;
                newProduct.Quantity = product.Quantity;
                newProduct.ProductInventory = new List<ProductInventory>();
                if (product.ProductInventory != null && product.ProductInventory.Count > 0)
                {
                    foreach (var productInventory in product.ProductInventory)
                    {
                        var newProductInventary = new ProductInventory
                        {
                            InventoryId = productInventory.InventoryId,
                            ProductId = productInventory.ProductId,
                            Product = product,
                            Inventory = new Inventory(),
                            InventoryQuantity = productInventory.InventoryQuantity
                        };
                        if (productInventory != null)
                        {
                            newProductInventary.Inventory.InventoryId = productInventory.Inventory.InventoryId;
                            newProductInventary.Inventory.InventoryName = productInventory.Inventory.InventoryName;
                            newProductInventary.Inventory.Price = productInventory.Inventory.Price;
                            newProductInventary.Inventory.Quantity = productInventory.Inventory.Quantity;
                        }

                        newProduct.ProductInventory.Add(newProductInventary);
                    }
                }
            }

            return await Task.FromResult(newProduct);
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var productToDelete = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToDelete is not null)
            {
                _products.Remove(productToDelete);
            }
            return Task.CompletedTask;
        }

    }
}
