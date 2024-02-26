using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.Product.Dto
{
    [AutoMapFrom(typeof(products))]
    public class ProductDto : EntityDto
    {
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Attachment { get; set; }
    }
}
