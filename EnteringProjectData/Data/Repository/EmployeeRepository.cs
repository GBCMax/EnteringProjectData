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
        public void AddEmployee(Employee employee)
        {
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChangesAsync();
        }
        public string AddEmployeeInProject(Project project, Employee employee)
        {
            var emp = _dbContext.Employee.Where(x => x.EmployeeID == employee.EmployeeID).Single();
            if (emp != null)
            {
                emp.Projects.Add(project);
                _dbContext.Employee.Update(emp);
                _dbContext.SaveChangesAsync();
                return "Добавлен";
            }
            return "Ошибка! Рабочий не найден!";
        }
    }
}
