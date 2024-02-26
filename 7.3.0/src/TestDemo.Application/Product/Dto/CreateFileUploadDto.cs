using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.FileUploadByDirective;

namespace TestDemo.Product.Dto
{
    [AutoMapTo(typeof(Productchild))]
    public class CreateFileUploadDto : EntityDto
    {
        public virtual int ProductId { get; set; }
        public virtual List<string> FileName { get; set; }
    }
}
