using System.ComponentModel.DataAnnotations;

namespace BlazorProgettoFinale.ViewModels.ViewModelsValidation
{
    public class Produce_EnsureEnoughInventoryQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;
            if (produceViewModel != null)
            {
                if (produceViewModel.Product != null)
                {
                    foreach (var productInventory in produceViewModel.Product.ProductInventory)
                    {
                        if (productInventory != null && productInventory.InventoryQuantity * produceViewModel.QuantityToProduce > productInventory.Inventory.Quantity)
                        {
                            return new ValidationResult($"The inventory ({productInventory.Inventory.InventoryName} is not enough to produce {produceViewModel.QuantityToProduce} products)",
                                new[] { validationContext.MemberName });
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
