using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FiboInfraStructure.Src;

namespace FiboSchool.Src.Dto
{
   public class TermDto : BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }







    }
    }
