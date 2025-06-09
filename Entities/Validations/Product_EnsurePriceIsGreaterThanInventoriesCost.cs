using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Validations
{
    public class Product_EnsurePriceIsGreaterThanInventoriesCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (!ValidatePricing(product))
                    return new ValidationResult($"The product's price is less than the inventories cost: ${TotalInventoriesCost(product).ToString("c")}!", new List<string>() { validationContext.MemberName});
            }

            return ValidationResult.Success;
        }

        private double TotalInventoriesCost(Product product)
        {
            if (product == null || product.ProductInventory == null) return 0;

            return product.ProductInventory.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        private bool ValidatePricing (Product product)
        {
            if (product == null || product.ProductInventory.Count <= 0) return true;

            if (TotalInventoriesCost(product) > product.Price) return false;

            return true;
        }
    }
}
