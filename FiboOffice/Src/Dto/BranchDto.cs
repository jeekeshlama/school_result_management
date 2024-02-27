using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Entity.FiboOffice;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.Src.Dto
{
    public class BranchDto : BaseDto
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public long? WardNo { get; set; }
        public long? OfficeId { get; set; }
        public virtual Office Office { get; set; }
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }

        public IList<Office> Offices { get; set; } = new List<Office>();
        public SelectList OfficeList => new SelectList(Offices, nameof(Office.Id), nameof(Office.Name));

        public IList<Provience> Proviencess { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviencess, nameof(Provience.Id), nameof(Provience.Name));

        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));

        public IList<LocalLevel> LocalLevels { get; set; } = new List<LocalLevel>();
        public SelectList LocalLevelList => new SelectList(LocalLevels, nameof(LocalLevel.Id), nameof(LocalLevel.Name));
    }
}
