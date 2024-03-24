using EnteringProjectData.Data.Models;
using EnteringProjectData.Data.Repository;

namespace EnteringProjectData.Data.ViewModels
{
    public class IndexViewModel
    {
        private EmployeeRepository employeeRepository;
        private ProjectRepository projectRepository;
        public List<Project> Projects { get; private set; } = new();
        public List<Employee> Employees { get; private set; } = new();
        public IndexViewModel() 
        {
            Projects = projectRepository.Projects.ToList();
            Employees = employeeRepository.Employees.ToList();
        }
        public void AddProject(Project project)
        {
            //projectRepository.AddEmployeeInProject();

        }
    }
}
