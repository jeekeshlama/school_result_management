using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Src
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
