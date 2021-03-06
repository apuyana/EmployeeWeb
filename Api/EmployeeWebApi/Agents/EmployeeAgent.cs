using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Agents
{
    public class EmployeeAgent
    {
        /// <summary>
        /// Identifier for a salary type.
        /// </summary>
        private const string EMPLOYEE_TYPE_HOUR = "hourlysalaryemployee";

        /// <summary>
        /// Identifier for a salary type.
        /// </summary>
        private const string EMPLOYEE_TYPE_MONTH = "monthlysalaryemployee";

        /// <summary>
        /// List cache to prevent round trip every time.
        /// On a real scenario this will have expiration.
        /// </summary>
        private static List<Employee> employeeCache = null;

        /// <summary>
        /// Remote web api client.
        /// </summary>
        private MasGlobal.EmployeeWebApi.IEmployeeWebApiClient remoteEmployeeWebApiClient;

        /// <summary>
        /// Remote web api client.
        /// </summary>
        public MasGlobal.EmployeeWebApi.IEmployeeWebApiClient RemoteEmployeeWebApiClient
        {
            get
            {
                if (remoteEmployeeWebApiClient == null)
                {
                    remoteEmployeeWebApiClient = new MasGlobal.EmployeeWebApi.EmployeeWebApiClient(baseUri: new Uri(ConfigurationManager.AppSettings["MG_EMPLOYEES_BASE_URI"]));
                }

                return remoteEmployeeWebApiClient;
            }

            set
            {
                remoteEmployeeWebApiClient = value;
            }
        }

        /// <summary>
        /// Get an specific employee.
        /// </summary>
        /// <param name="id">Id to filter.</param>
        /// <returns>Task to await.</returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            Employee foundEmployee = null;

            var employees = await GetEmployeesAsync();

            if (employees != null)
            {
                foundEmployee = (from employee in employees
                                 where employee.Id == id
                                 select employee).FirstOrDefault();
            }

            return foundEmployee;
        }

        /// <summary>
        /// Get the list of employees from the server.
        /// </summary>
        /// <returns>Task to await.</returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = null;

            if (employeeCache == null)
            {
                try
                {
                    Microsoft.Rest.HttpOperationResponse<IList<MasGlobal.EmployeeWebApi.Models.Employee>> remoteResult = await RemoteEmployeeWebApiClient.ApiEmployeesGetWithHttpMessagesAsync();

                    if (remoteResult.Response.IsSuccessStatusCode && remoteResult.Body != null && remoteResult.Body.Count > 0)
                    {
                        employees = new List<Employee>();
                        Employee newEmployee;

                        for (int i = 0; i < remoteResult.Body.Count; i++)
                        {
                            newEmployee = InstantiateEmployee(remoteResult.Body[i]);
                            if (newEmployee != null)
                            {
                                employees.Add(newEmployee);
                            }
                        }

                        employeeCache = employees;
                    }
                }
                catch (Exception ex)
                {
                    // No exception handling implemented.
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                employees = employeeCache;
            }

            return employees;
        }

        /// <summary>
        /// Factory method to instantiate the correct employee type.
        /// </summary>
        /// <param name="remoteEmployee"></param>
        /// <returns></returns>
        internal Employee InstantiateEmployee(MasGlobal.EmployeeWebApi.Models.Employee remoteEmployee)
        {
            Employee newEmployee = null;

            if (remoteEmployee != null)
            {
                switch (remoteEmployee.ContractTypeName.ToLowerInvariant())
                {
                    case EMPLOYEE_TYPE_HOUR:
                        newEmployee = new EmployeeHourly()
                        {
                            Id = remoteEmployee.Id ?? 0,
                            Name = remoteEmployee.Name,
                            HourlySalary = remoteEmployee.HourlySalary,
                            RoleName = remoteEmployee.RoleName
                        };
                        break;

                    case EMPLOYEE_TYPE_MONTH:
                        newEmployee = new EmployeeMonthly()
                        {
                            Id = remoteEmployee.Id ?? 0,
                            Name = remoteEmployee.Name,
                            MonthlySalary = remoteEmployee.MonthlySalary,
                            RoleName = remoteEmployee.RoleName
                        };
                        break;

                    default:
                        break;
                }
            }

            return newEmployee;
        }
    }
}