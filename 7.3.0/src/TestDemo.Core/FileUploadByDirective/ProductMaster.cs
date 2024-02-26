using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.FileUploadByDirective
{
    [Table("ProductMaster")]
    public class Productmaster : FullAuditedEntity
    {
        public virtual string ProductComment { get; set; }
    }
}
