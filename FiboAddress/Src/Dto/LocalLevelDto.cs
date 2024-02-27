using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiboAddress.Src.Dto
{
   public class LocalLevelDto :BaseDto
    {
        public string Name { get; set; }
        public long? DistrictId { get; set; }

        public IList<District> Districts { get; set; } = new List<District>();
        public SelectList DistrictList => new SelectList(Districts, nameof(District.Id), nameof(District.Name));
    }
}
