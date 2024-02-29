using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.FileUploadByDirective
{
    [Table("ProductChild")]
    public class Productchild : FullAuditedEntity
    {
        public virtual int ProductId { get; set; }
        public virtual string Attachment { get; set; }
    }
}
