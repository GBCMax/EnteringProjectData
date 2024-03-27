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
        public IndexViewModel(DBContext dBContext) 
        {
            projectRepository = new ProjectRepository(dBContext);
            employeeRepository = new EmployeeRepository(dBContext);
            Projects = projectRepository.Projects.ToList();
            Employees = employeeRepository.Employees.ToList();
        }
    }
}
