using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EnteringProjectData.Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project name is empty!")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Customer company name is empty!")]
        public string CustomerCompanyName { get; set; }

        [Required(ErrorMessage = "Executing company name is empty!")]
        public string ExecutingCompanyName { get; set; }

        [Required(ErrorMessage = "Start date is empty!")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is empty!")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Priority is empty!")]
        public int Priority { get; set; }
        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
        public Project()
        {
            EmployeeProjects = new List<EmployeeProject>();
        }

    }
}
