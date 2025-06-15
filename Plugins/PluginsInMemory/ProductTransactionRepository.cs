using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace PluginsInMemory
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private List<ProductTransaction> _productTransactions = new List<ProductTransaction>();

        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IInventoryRepository inventoryRepository;

        public ProductTransactionRepository(IProductRepository productRepository,IInventoryTransactionRepository inventoryTransactionRepository, IInventoryRepository inventoryRepository)
        {
            this.productRepository = productRepository;
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
             
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);
            if (prod != null)
            {
                foreach ( var productInventory in prod.ProductInventory )
                {
                    if (productInventory != null)
                    {
                        await this.inventoryTransactionRepository.ProduceAsync(productionNumber, productInventory.Inventory, productInventory.InventoryQuantity * quantity, doneBy, -1);

                        var inventory = await this.inventoryRepository.GetInventoryByIdAsync(productInventory.InventoryId);
                        inventory.Quantity -= productInventory.InventoryQuantity * quantity;

                        await this.inventoryRepository.UpdateInventoryAsync(inventory);
                    }
                }
            }

            this._productTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity + quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
            });
            
        }
    }
}
