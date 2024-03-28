using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EnteringProjectData.Data.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "First name is empty!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is empty!")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Patronymic is empty!")]
        public string Patronymic { get; set; }

        [EmailAddress (ErrorMessage = "Incorrect email!")]
        public string Email { get; set; }

        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
        public Employee() 
        {
            EmployeeProjects = new List<EmployeeProject>();
        }
    }
}
