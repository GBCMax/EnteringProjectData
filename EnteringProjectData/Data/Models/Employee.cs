using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EnteringProjectData.Data.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Email { get; set; }
        public int? ProjectID { get; set; }
        public virtual Project? Project { get; set; }
        public void SetProject(Project project)
        {
            ProjectID = project.ProjectId;
            Project = project;
        }
        public Employee() 
        { 
        }
    }
}
