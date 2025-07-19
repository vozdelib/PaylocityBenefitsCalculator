using Api.Models;
using Api.Services.Calculation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiTests.Services.Calculation
{
    public class DependentBenefitCostStrategyTests
    {
        private static DateTime TODAY => new DateTime(2025, 7, 19);

        private Dependent CreateDependent(DateTime dob, Relationship relationship)
        {
            return new Dependent
            {
                DateOfBirth = dob,
                Relationship = relationship
            };
        }

        private Employee CreateEmployee(params Dependent[] dependents)
        {
            return new Employee
            {
                Salary = 50000m,
                DateOfBirth = new DateTime(1980, 1, 1),
                Dependents = new List<Dependent>(dependents)
            };
        }

        private DependentBenefitCostStrategy CreateStrategyWithFixedDate()
        {
            var dateProviderMock = new Mock<IDateTimeProvider>();
            dateProviderMock.Setup(x => x.Today).Returns(TODAY);
            return new DependentBenefitCostStrategy(dateProviderMock.Object);
        }

        [Fact]
        public void CalculateMonthlyCost_NoDependents()
        {
            var strategy = CreateStrategyWithFixedDate();
            var employee = CreateEmployee();

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateMonthlyCost_SpouseUnder50()
        {
            var strategy = CreateStrategyWithFixedDate();
            var spouse = CreateDependent(TODAY.AddYears(-40), Relationship.Spouse);
            var employee = CreateEmployee(spouse);

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(600m, result);
        }

        [Fact]
        public void CalculateMonthlyCost_DomesticPartnerOver50()
        {
            var strategy = CreateStrategyWithFixedDate();
            var partner = CreateDependent(TODAY.AddYears(-51), Relationship.DomesticPartner);
            var employee = CreateEmployee(partner);

            var result = strategy.CalculateMonthlyCost(employee);

            // 600 base + 200 additional for age > 50
            Assert.Equal(800m, result);
        }

        [Fact]
        public void CalculateMonthlyCost_OneChildUnder50()
        {
            var strategy = CreateStrategyWithFixedDate();
            var child = CreateDependent(TODAY.AddYears(-10), Relationship.Child);
            var employee = CreateEmployee(child);

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(600m, result);
        }

        [Fact]
        public void CalculateMonthlyCost_OneChildOver50()
        {
            var strategy = CreateStrategyWithFixedDate();
            var child = CreateDependent(TODAY.AddYears(-60), Relationship.Child);
            var employee = CreateEmployee(child);

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(800m, result);
        }

        [Fact]
        public void CalculateMonthlyCost_MultipleChildren_MixedAges()
        {
            var strategy = CreateStrategyWithFixedDate();
            var child1 = CreateDependent(TODAY.AddYears(-10), Relationship.Child); // 600
            var child2 = CreateDependent(TODAY.AddYears(-60), Relationship.Child); // 600 + 200
            var employee = CreateEmployee(child1, child2);

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(1400m, result); // 600 + 800
        }

        [Fact]
        public void CalculateMonthlyCost_MixedDependents()
        {
            var strategy = CreateStrategyWithFixedDate();
            var spouse = CreateDependent(TODAY.AddYears(-40), Relationship.Spouse); // 600
            var partner = CreateDependent(TODAY.AddYears(-51), Relationship.DomesticPartner); // 600 + 200
            var child = CreateDependent(TODAY.AddYears(-10), Relationship.Child); // 600
            var childOld = CreateDependent(TODAY.AddYears(-60), Relationship.Child); // 600 + 200
            var employee = CreateEmployee(spouse, partner, child, childOld);

            var result = strategy.CalculateMonthlyCost(employee);

            Assert.Equal(2800m, result); // 600 + 800 + 600 + 800
        }
    }
}
