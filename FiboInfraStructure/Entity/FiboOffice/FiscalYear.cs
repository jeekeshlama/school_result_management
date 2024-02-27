using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Entity.FiboOffice
{
    public class FiscalYear: BaseSetup
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

        public string FiscalYearName { get; set; }
        public string FiscalYearCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}
