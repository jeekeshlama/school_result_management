using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FiboInfraStructure.Entity.FiboAddress;
using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiboAddress.Src.Dto
{
   public class DistrictDto : BaseDto
    {
        public string Name { get; set; }

        public long? ProvienceId { get; set; }

        public IList<Provience> Proviences { get; set; } = new List<Provience>();
        public SelectList ProvienceList => new SelectList(Proviences, nameof(Provience.Id), nameof(Provience.Name));
    }
}
