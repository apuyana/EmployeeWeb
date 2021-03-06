using EmployeeWebApiTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Agents.Tests
{
    [TestClass()]
    public class EmployeeAgentTests
    {
        [TestMethod()]
        public async Task CalculateHourlyCorrectlyAsyncTest()
        {
            EmployeeAgent employeeAgent = new EmployeeAgent();

            employeeAgent.RemoteEmployeeWebApiClient = new RemoteEmployeeWebApiClientMock();

            Models.Employee result = await employeeAgent.GetEmployeeByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is Models.EmployeeHourly);
            Assert.IsTrue(result.AnnualSalary == 1440);
        }

        [TestMethod()]
        public async Task CalculateMonthlyCorrectlyAsyncTest()
        {
            EmployeeAgent employeeAgent = new EmployeeAgent();

            employeeAgent.RemoteEmployeeWebApiClient = new RemoteEmployeeWebApiClientMock();

            Models.Employee result = await employeeAgent.GetEmployeeByIdAsync(2);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is Models.EmployeeMonthly);
            Assert.IsTrue(result.AnnualSalary == 12);
        }

        [TestMethod()]
        public async Task GetAllEmployeesAsyncTest()
        {
            EmployeeAgent employeeAgent = new EmployeeAgent();

            employeeAgent.RemoteEmployeeWebApiClient = new RemoteEmployeeWebApiClientMock();

            IEnumerable<Models.Employee> results = await employeeAgent.GetEmployeesAsync();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() == 3);
        }

        [TestMethod()]
        public async Task GetEmployeeByIdAsyncTest()
        {
            EmployeeAgent employeeAgent = new EmployeeAgent();

            employeeAgent.RemoteEmployeeWebApiClient = new RemoteEmployeeWebApiClientMock();

            Models.Employee result = await employeeAgent.GetEmployeeByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is Models.EmployeeHourly);

            result = await employeeAgent.GetEmployeeByIdAsync(2);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is Models.EmployeeMonthly);
        }
    }
}