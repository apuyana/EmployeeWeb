// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MasGlobal.EmployeeWebApi.Models
{
    using Newtonsoft.Json;

    public partial class Employee
    {
        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee(int? id = default(int?), string name = default(string), string contractTypeName = default(string), int? roleId = default(int?), string roleName = default(string), string roleDescription = default(string), double? hourlySalary = default(double?), double? monthlySalary = default(double?))
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contractTypeName")]
        public string ContractTypeName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hourlySalary")]
        public double? HourlySalary { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "monthlySalary")]
        public double? MonthlySalary { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "roleDescription")]
        public string RoleDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "roleId")]
        public int? RoleId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }
    }
}