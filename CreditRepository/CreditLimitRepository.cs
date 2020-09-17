using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditRepository
{
    public class CreditLimitRepository : ICreditLimitRepository
    {
        public CreditLimitRepository()
        {

        }
        public void CheckUtilization(List<CreditLimits> objCreditLimits)
        {
            StringBuilder entityList = new StringBuilder();
            List<CreditLimits> creditLimits = new List<CreditLimits>();
            int totaltilization = 0;
            int creditLimit = 0;
            int directUtil = 0;

            var objList = (from data in objCreditLimits
                           group data by new { data.Parent, data.Entity } into g
                           orderby g.Key.Entity
                           select g);
                     
            foreach (var obj in objList)
            {
                if (obj.Key.Parent == "")
                {
                    if (entityList.Length > 0)
                    {
                        totaltilization = creditLimits.Sum(i => i.Utilization);
                        creditLimit = creditLimits.FirstOrDefault().CreditLimit;
                        if (totaltilization < creditLimit)
                            Console.WriteLine("Entities: {0}: \r\n\t No Limit Breaches", entityList.ToString());
                        else
                        {
                            directUtil = creditLimits.FirstOrDefault().Utilization;
                            Console.WriteLine("Entities: {0}: \r\n\t Limit breach at {1} (limit = {2}, direct utilisation = {3}, combined utilisation={4})", entityList.ToString(), entityList[0].ToString(), creditLimit, directUtil, totaltilization);
                        }
                        entityList.Clear();
                        creditLimits.Clear();
                    }
                    entityList.Append(obj.Key.Entity + "/");
                }
                else
                    entityList.Append(obj.Key.Entity + "/");
                foreach (var item in obj)
                {
                    creditLimits.Add(item);
                }
            }

            if (entityList.Length > 0)
            {
                totaltilization = creditLimits.Sum(i => i.Utilization);
                creditLimit = creditLimits.FirstOrDefault().CreditLimit;
                if (totaltilization < creditLimit)
                    Console.WriteLine("Entities: {0}: \r\n\t No Limit Breaches", entityList.ToString());
                else
                {
                    directUtil = creditLimits.FirstOrDefault().Utilization;
                    Console.WriteLine("Entities: {0}: \r\n\t Limit breach at {1} (limit = {2}, direct utilisation = {3}, combined utilisation={4})", entityList.ToString(), entityList[0].ToString(), creditLimit, directUtil, totaltilization);
                }
                entityList.Clear();
                creditLimits.Clear();
            }

            Console.ReadLine();
        }
    }
}
