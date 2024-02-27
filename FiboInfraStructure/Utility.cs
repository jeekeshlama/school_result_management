using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiboInfraStructure
{
    public static class Utility
    {
        public static Int32 ToInt32(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }
        public static string ToText(this object o)
        {
            try
            {
                return o.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static Decimal ToDecimal(this object o)
        {
            try
            {
                return Convert.ToDecimal(o);
            }
            catch
            {
                return 0.0M;
            }
        }
        public static DateTime? ToDateTime(this object o)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch
            {
                return null;
            }
        }
        public static DateTime? ToEnglishDate(this object o)
        {
            try
            {
                var chunks = o.ToText().Split('-', '/', '.');
                if (chunks.Length != 3)
                {
                    return null;
                }
                int year = chunks[0].ToInt32();
                int month = chunks[1].ToInt32();
                int day = chunks[2].ToInt32();
                return NepDateConverter.NepToEng(year, month, day);
            }
            catch
            {
                return null;
            }
        }

        public static string ToNepaliDate(DateTime dt)
        {
            try
            {
                NepDate nepDate = NepDateConverter.EngToNep(dt.Year, dt.Month, dt.Day);
                return string.Format("{0}-{1}-{2}", nepDate.Year, nepDate.Month, nepDate.Day);
            }
            catch
            {
                return null;
            }
        }
        public static string ToNepDate(this DateTime? dt)
        {
            if (dt == null)
            {
                return null;
            }
            return ToNepaliDate((DateTime)dt);
        }
    }
}
