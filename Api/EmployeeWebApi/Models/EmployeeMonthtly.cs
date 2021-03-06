namespace EmployeeWebApi.Models
{
    /// <summary>
    /// Employee that has hourly contract.
    /// </summary>
    public partial class EmployeeMonthly : Employee
    {
        /// <summary>
        /// Annual salary
        /// </summary>
        public override double AnnualSalary
        {
            get
            {
                return MonthlySalary.HasValue ? MonthlySalary.Value * 12d : 0;
            }
        }

        /// <summary>
        /// Monthly Salary
        /// </summary>
        public double? MonthlySalary { get; set; }
    }
}