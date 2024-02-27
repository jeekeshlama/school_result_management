using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FiboInfraStructure.BaseInfraStructure;
using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiboOffice.Src.Dto
{
   public class OfficeDto :BaseDto
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string FAX { get; set; }
        public string PANNo { get; set; }
        public long? FiscalYearId { get; set; }
        public long? ProvienceId { get; set; }
        public virtual Provience Provience { get; set; }
        public long? DistrictId { get; set; }
        public virtual District District { get; set; }
        public long? LocalLevelId { get; set; }
        public virtual LocalLevel LocalLevel { get; set; }
        [NotMapped()]
        public IFormFile OfficeLogo { get; set; }
        public IList<Provience> Proviencess { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviencess, nameof(Provience.Id), nameof(Provience.Name));

        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));

        public IList<LocalLevel> LocalLevels { get; set; } = new List<LocalLevel>();
        public SelectList LocalLevelList => new SelectList(LocalLevels, nameof(LocalLevel.Id), nameof(LocalLevel.Name));
    }
}
