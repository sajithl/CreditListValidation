using CreditRepository;
using Moq;
using NUnit.Framework;
using DataModel;
using System.Collections.Generic;
using System;


namespace CreditValidationTest
{
    public class Tests
    {
        private Mock<ICreditLimitRepository> mockCredit;
        private List<CreditLimits> creditLimit;

        [SetUp]
        public void Setup()
        {
            mockCredit = new Mock<ICreditLimitRepository>();
            creditLimit = new List<CreditLimits>
            {
                new CreditLimits { Entity = "A", Parent = "", CreditLimit = 100, Utilization = 0 },
                new CreditLimits { Entity = "B", Parent = "A", CreditLimit = 90, Utilization = 10 },
                new CreditLimits { Entity = "C", Parent = "B", CreditLimit = 40, Utilization = 20 },
                new CreditLimits { Entity = "D", Parent = "B", CreditLimit = 40, Utilization = 20 },
                new CreditLimits { Entity = "E", Parent = "", CreditLimit = 200, Utilization = 150 },
                new CreditLimits { Entity = "F", Parent = "E", CreditLimit = 100, Utilization = 80 }
            };
        }

        [Test]
        public void PositiveTest()
        {
            mockCredit.Object.CheckUtilization(creditLimit);            
        }
    }
}