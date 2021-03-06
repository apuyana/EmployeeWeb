namespace EmployeeWebApi.Models
{
    /// <summary>
    /// Employee with details.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Annual salary
        /// </summary>
        public abstract double AnnualSalary { get; }

        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string RoleName { get; set; }
    }
}