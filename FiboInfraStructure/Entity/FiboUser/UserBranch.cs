using FiboInfraStructure.Entity.FiboOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboUser
{
    public class UserBranch
    {
        [Key()]
        public long UserBranchId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("BranchId")]
        public long? BranchId { get; set; }

        [NotMapped()]
        public virtual Branch Branch { get; set; }
    }
}
