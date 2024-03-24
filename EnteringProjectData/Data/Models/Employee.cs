using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EnteringProjectData.Data.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public virtual List<Project>? Projects { get; set; }
        public void AddEmpInProject(Project project)
        {
            Projects.Add(project);
        }
    }
}
