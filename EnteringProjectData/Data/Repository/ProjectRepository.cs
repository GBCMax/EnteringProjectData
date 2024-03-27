using EnteringProjectData.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EnteringProjectData.Data.Repository
{
    public class ProjectRepository
    {
        private readonly DBContext _dbContext;
        public ProjectRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Project> Projects => _dbContext.Project;
        public Project GetProject(int projectID) => _dbContext.Project.FirstOrDefault(x => x.ProjectId == projectID);
        public async Task AddProject(Project project)
        {
            if(!_dbContext.Project.Contains(project))
            {
                _dbContext.Project.Add(project);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddEmployeeInProject(Project project, Employee employee)
        {
            var p = _dbContext.Project.Where(x => x.ProjectId == project.ProjectId).Single();
            var emp = _dbContext.Employee.Where(x => x.EmployeeID == employee.EmployeeID).Single();
            if (p != null)
            {
                p.AddEmpInProject(employee);
                emp.SetProject(project);
                //p.Employees.Add(employee);
                //_dbContext.Employee.Update(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
