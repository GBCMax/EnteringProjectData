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

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public void AddEmpInProject(Employee employee)
        {
            Employees.Add(employee);
        }
        public Project()
        {
            Employees = new List<Employee>();
        }

    }
}
