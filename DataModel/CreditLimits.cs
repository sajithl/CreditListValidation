using System;

namespace DataModel
{
    public class CreditLimits
    {
        public string Entity { get; set; }
        public string Parent { get; set; }
        public int CreditLimit { get; set; }
        public int Utilization { get; set; }

        public static CreditLimits FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            CreditLimits creditValues = new CreditLimits
            {
                Entity = Convert.ToString(values[0].Trim()),
                Parent = Convert.ToString(values[1].Trim()),
                CreditLimit = Convert.ToInt32(values[2].Trim()),
                Utilization = Convert.ToInt32(values[3].Trim())
            };
            return creditValues;
        }
    }
}
