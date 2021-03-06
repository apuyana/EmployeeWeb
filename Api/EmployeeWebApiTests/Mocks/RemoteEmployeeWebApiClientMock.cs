using MasGlobal.EmployeeWebApi;
using MasGlobal.EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeWebApiTests.Mocks
{
    internal class RemoteEmployeeWebApiClientMock : IEmployeeWebApiClient
    {
        public Task<Microsoft.Rest.HttpOperationResponse<IList<Employee>>> ApiEmployeesGetWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee()
            {
                Id = 1,
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 1,
                MonthlySalary = 20,
                Name = "Name 1",
                RoleName = "Role 1"
            });

            employees.Add(new Employee()
            {
                Id = 2,
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 20,
                MonthlySalary = 1,
                Name = "Name 2",
                RoleName = "Role 2"
            });

            employees.Add(new Employee()
            {
                Id = 3,
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 3,
                MonthlySalary = 3,
                Name = "Name 3",
                RoleName = "Role 3"
            });

            Microsoft.Rest.HttpOperationResponse<IList<Employee>> response = new Microsoft.Rest.HttpOperationResponse<IList<Employee>>()
            {
                Body = employees,
                Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
            };

            return Task.FromResult(response);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}