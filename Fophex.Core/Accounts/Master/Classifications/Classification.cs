using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.Core.Accounts.Master.SubClassifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.Classifications
{

    [Table(name: "Classifications", Schema = "account")]
    public class Classification : AuditedEntity, IMustHaveTenant
    {
       

        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public long? TenantId { get; set; }
        public long SubCategoryId { get; set; }

        // Navigation property
        public SubCategory SubCategory { get; set; }

        public ICollection<SubClassification> SubClassifications { get; set; }



    }
}
