namespace EmployeeWebApi.Models
{
    /// <summary>
    /// Employee that has hourly contract.
    /// </summary>
    public partial class EmployeeHourly : Employee
    {
        /// <summary>
        /// Annual salary
        /// </summary>
        public override double AnnualSalary
        {
            get
            {
                return HourlySalary.HasValue ? 120d * HourlySalary.Value * 12d : 0;
            }
        }

        /// <summary>
        /// Hourly salary
        /// </summary>
        public double? HourlySalary { get; set; }
    }
}