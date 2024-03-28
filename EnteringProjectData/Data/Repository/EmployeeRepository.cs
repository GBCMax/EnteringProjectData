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
    }
}
