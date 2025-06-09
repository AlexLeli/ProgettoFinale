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
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        public readonly IProductRepository productRepository;


        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product?> ExecuteAsync(int productId)
        {
            return await productRepository.GetProductByIdAsync(productId);
        }
    }
}
