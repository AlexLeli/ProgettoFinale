using System.ComponentModel.DataAnnotations;
using CoreBusiness.Validations;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long")]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0.")]
        public int Quantity { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0.")]
        public double Price { get; set; }

        [Product_EnsurePriceIsGreaterThanInventoriesCost]
        public List<ProductInventory> ProductInventory { get; set; } = new List<ProductInventory>();
        
        public void AddInventory(Inventory inventory)
        {
            if (!this.ProductInventory.Any(x => x.Inventory is not null && x.Inventory.InventoryName.Equals(inventory.InventoryName)))
                this.ProductInventory.Add(new ProductInventory
                {
                    InventoryId = inventory.InventoryId,
                    Inventory = inventory,
                    InventoryQuantity = 1,
                    ProductId = this.ProductId,
                    Product = this
                });
        }

        public void RemoveInventory(ProductInventory productInventory)
        {
            this.ProductInventory?.Remove(productInventory);
        }
    }
}
