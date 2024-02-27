using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboOffice
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public long? WardNo { get; set; }

        [ForeignKey("OfficeId")]
        public long? OfficeId { get; set; }
        public virtual Office Office { get; set; }

        [ForeignKey("ProvienceId")]
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }

        [ForeignKey("DistrictId")]
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }

        [ForeignKey("LocalLevelId")]
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
    }
}
