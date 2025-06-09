using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.Products.Interfaces;

namespace UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        public readonly IProductRepository productRepository;


        public AddProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(Product product)
        {
            await productRepository.AddProductAsync(product);
        }
    }
}
