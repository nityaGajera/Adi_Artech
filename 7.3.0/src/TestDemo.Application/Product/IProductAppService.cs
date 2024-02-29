using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Product.Dto;

namespace TestDemo.Product
{
    public interface IProductAppService : IApplicationService
    {
        List<ProductDto> GetProductData();
        Task CreateProduct(CreateProductDto input);
        Task<ProductDto> getProductbyid(EntityDto input);
        Task UpdateProduct(CreateProductDto input);
        Task DeleteProduct(EntityDto input);
        //Task<int> CreateFileUploadProduct(CreateFileUploadDto input);
        Task FileUploadProduct(FileUploadDto input);
        bool ProductExsistenceById(ProductDto input);
        bool ProductExsistence(ProductDto input);
    }
}
