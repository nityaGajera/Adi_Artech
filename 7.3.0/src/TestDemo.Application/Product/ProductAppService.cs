using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Product.Dto;

namespace TestDemo.Product
{
    public class ProductAppService : TestDemoApplicationModule, IProductAppService
    {
        private readonly IRepository<products> _ProductRepository;

        public ProductAppService(IRepository<products> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public List<ProductDto> GetProductData()
        {
            var product = (from a in _ProductRepository.GetAll()
                        select new ProductDto
                        {
                            Id = a.Id,
                            Name = a.Name,
                        }).ToList();
            return product;
        }

        public async Task CreateProduct(CreateProductDto input)
        {
            var product = input.MapTo<products>();
            await _ProductRepository.InsertAsync(product);
        }

        public async Task<ProductDto> getProductbyid(EntityDto input)
        {
            await _ProductRepository.GetAsync(input.Id);
            var Products = (from a in _ProductRepository.GetAll()
                         where a.Id == input.Id
                         select new ProductDto
                         {
                             Id = a.Id,
                             Name = a.Name,
                         }).FirstOrDefault();
            return Products;
        }
        public async Task UpdateProduct(CreateProductDto input)
        {
            var Products = await _ProductRepository.GetAsync(input.Id);
            Products.Name = input.Name;
            await _ProductRepository.UpdateAsync(Products);
        }
        public async Task DeleteProduct(EntityDto input)
        {
            await _ProductRepository.DeleteAsync(input.Id);
        }
    }
}
