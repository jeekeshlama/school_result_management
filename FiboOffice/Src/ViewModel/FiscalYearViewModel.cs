using FiboInfraStructure.Entity.FiboOffice;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboOffice.Src.ViewModel
{
    public class FiscalYearViewModel
    {
        public string Status { get; set; }
        public virtual List<FiscalYear> FiscalYears { get; set; }
    }
}
