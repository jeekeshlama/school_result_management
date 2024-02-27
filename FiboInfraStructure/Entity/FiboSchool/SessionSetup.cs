using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboInfraStructure.Entity.FiboSchool
{
    public class SessionSetup : BaseSetup
    {
        private readonly string StatusActive = "Active";
        private readonly string StatusInactive = "Inactive";

        public bool IsActive()
        {
            return Status == StatusActive;
        }

        public bool IsInactive()
        {
            return Status == StatusInactive;
        }

        public void Activate()
        {
            Status = StatusActive;
        }

        public void Deactive()
        {
            Status = StatusInactive;
        }

        public void ChangeStatus()
        {
            if (IsActive())
            {
                Deactive();
            }
            else
            {
                Activate();
            }
        }
        public string Session { get; set; }
        public string Status { get; set; }
    }
}
