using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestDemo.FileUploadByDirective;
using TestDemo.Product.Dto;

namespace TestDemo.Product
{
    public class ProductAppService : TestDemoApplicationModule, IProductAppService
    {
        private readonly IRepository<products> _ProductRepository;
        //private readonly IRepository<Productmaster> _productmasterRepository;
        private readonly IRepository<Productchild> _productchildRepository;

        public ProductAppService(IRepository<products> ProductRepository, /*IRepository<Productmaster> productmasterRepository*/ IRepository<Productchild> productchildRepository)
        {
            _ProductRepository = ProductRepository;
            //_productmasterRepository = productmasterRepository;
            _productchildRepository = productchildRepository;
        }
        public List<ProductDto> GetProductData()
        {
            var product = (from a in _ProductRepository.GetAll()
                        select new ProductDto
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Attachment = a.Attachment,
                        }).ToList();
            return product;
        }

        public async Task CreateProduct(CreateProductDto input)
        {
            var product = input.MapTo<products>();
            await _ProductRepository.InsertAndGetIdAsync(product);
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
                             Attachment = a.Attachment,
                         }).FirstOrDefault();
            return Products;
        }
        public async Task UpdateProduct(CreateProductDto input)
        {
            var Products = await _ProductRepository.GetAsync(input.Id);
            Products.Name = input.Name;
            Products.Attachment = input.Attachment;
            await _ProductRepository.UpdateAsync(Products);
        }
        public async Task DeleteProduct(EntityDto input)
        {
            await _ProductRepository.DeleteAsync(input.Id);
        }
        public bool ProductExsistence(ProductDto input)
        {
            return _ProductRepository.GetAll().Where(e => e.Attachment == input.Attachment).Any();
        }
        public bool ProductExsistenceById(ProductDto input)
        {
            return _ProductRepository.GetAll().Where(e => e.Attachment == input.Attachment && e.Id != input.Id).Any();
        }

        //public async Task<int> CreateFileUploadProduct(CreateFileUploadDto input)
        //{
        //    var Products = input.MapTo<Productmaster>();
        //    int Id = await _productmasterRepository.InsertAndGetIdAsync(Products);
        //    return Id;
        //}
        public async Task FileUploadProduct(FileUploadDto input)
        {
            if (input.Attachment != null && input.Attachment.Count() != 0)
            {
                for (int i = 0; i < input.Attachment.Count(); i++)
                {
                    Productchild doc = new Productchild();
                    doc.Attachment = input.Attachment[i];
                    doc.ProductId = input.Id;
                    await _productchildRepository.InsertAsync(doc);
                }
            }
        }
    }
}
