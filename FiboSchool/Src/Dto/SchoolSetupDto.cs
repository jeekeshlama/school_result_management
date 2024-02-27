using FiboInfraStructure.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboSchool.Src.Dto
{
   public class SchoolSetupDto:BaseDto
    {
        public string SchoolName { get; set; }
        public string SchoolSlogan { get; set; }
        public string Address { get; set; }
        public string Signature { get; set; }
    }
}
