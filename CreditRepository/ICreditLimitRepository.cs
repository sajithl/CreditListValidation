using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditRepository
{
    public interface ICreditLimitRepository
    {
        void CheckUtilization(List<CreditLimits> objCreditLimits);
    }
}
