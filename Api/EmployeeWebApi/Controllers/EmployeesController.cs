using EmployeeWebApi.Agents;
using EmployeeWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Agent for the employees.
        /// </summary>
        private static EmployeeAgent employeeAgent;

        /// <summary>
        /// Agent for the employees.
        /// </summary>
        protected static EmployeeAgent EmployeeAgent
        {
            get
            {
                if (employeeAgent == null)
                {
                    employeeAgent = new EmployeeAgent();
                }

                return employeeAgent;
            }
        }

        /// <summary>
        ///  GET: api/Employees
        /// </summary>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await EmployeeAgent.GetEmployeesAsync();
        }

        /// <summary>
        /// GET: api/Employees/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<Employee> Get(int id)
        {
            return await EmployeeAgent.GetEmployeeByIdAsync(id);
        }
    }
}