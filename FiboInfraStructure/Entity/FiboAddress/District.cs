using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboAddress
{
   public class District : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }
        [NotMapped()]
        public virtual Provience Provience { get; set; }

    }
}
