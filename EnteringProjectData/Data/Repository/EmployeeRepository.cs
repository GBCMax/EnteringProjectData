using EnteringProjectData.Data.Models;

namespace EnteringProjectData.Data.Repository
{
    public class EmployeeRepository
    {
        private readonly DBContext _dbContext;
        public EmployeeRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Employee> Employees => _dbContext.Employee;
        public Employee GetEmployee(int employeeID) => _dbContext.Employee.FirstOrDefault(x => x.EmployeeID == employeeID);
        public async Task AddEmployee(Employee employee)
        {
            if(!_dbContext.Employee.Contains(employee))
            {
                _dbContext.Employee.Add(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SetProject(Project project, Employee employee)
        {
            var emp = _dbContext.Employee.Where(x => x.EmployeeID == employee.EmployeeID).Single();
            var p = _dbContext.Project.Where(x => x.ProjectId == project.ProjectId).Single();
            if (emp != null && p != null)
            {
                if (!p.Employees.Contains(emp))
                {
                    p.Employees.Add(emp);
                    //_dbContext.TaskProject.Update(task);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
