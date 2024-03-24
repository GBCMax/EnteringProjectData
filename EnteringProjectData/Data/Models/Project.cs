using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EnteringProjectData.Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string ExecutingCompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public void AddEmpInProject(Employee employee)
        {
            Employees.Add(employee);
        }

    }
}
