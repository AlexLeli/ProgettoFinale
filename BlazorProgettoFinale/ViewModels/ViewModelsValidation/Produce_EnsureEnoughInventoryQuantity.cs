using System.ComponentModel.DataAnnotations;
using UseCases.Interfaces;

namespace BlazorProgettoFinale.ViewModels.ViewModelsValidation
{
    public class Produce_EnsureEnoughInventoryQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;
            var repository = (IInventoryRepository?)validationContext.GetService(typeof(IInventoryRepository));
            if (produceViewModel != null)
            {
                
                if (produceViewModel.Product != null && produceViewModel.Product.ProductInventory != null)
                {
                    foreach (var productInventory in produceViewModel.Product.ProductInventory)
                    {
                        var fullProduct =  repository.GetInventoryByIdAsync(productInventory.InventoryId).GetAwaiter().GetResult();

                        if (productInventory != null && productInventory.InventoryQuantity * produceViewModel.QuantityToProduce > fullProduct.Quantity)
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
