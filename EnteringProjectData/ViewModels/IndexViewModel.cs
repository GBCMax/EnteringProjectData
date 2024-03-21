using EnteringProjectData.Models;

namespace EnteringProjectData.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
