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
        public void AddProject(Project project)
        {
            _dbContext.Project.Add(project);
            _dbContext.SaveChangesAsync();
        }
        public string AddEmployeeInProject(Project project, Employee employee)
        {
            var p = _dbContext.Project.Where(x => x.ProjectId == project.ProjectId).Single();
            if (p != null)
            {
                p.Employees.Add(employee);
                _dbContext.Project.Update(p);
                _dbContext.SaveChangesAsync();
                return "Добавлен";
            }
            return "Ошибка! Проект не найден!";
        }
    }
}
