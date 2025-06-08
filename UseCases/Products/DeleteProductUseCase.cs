using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.Products.Interfaces;

namespace UseCases.Products.Interfaces
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        public readonly IProductRepository productRepository;


        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(int productId)
        {
            await productRepository.DeleteProductByIdAsync(productId);
        }
    }
}
