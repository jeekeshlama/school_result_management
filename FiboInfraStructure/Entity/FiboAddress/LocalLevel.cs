using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboAddress
{
   public class LocalLevel : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }
        [NotMapped()]
        public virtual District District { get; set; }
    }
}
