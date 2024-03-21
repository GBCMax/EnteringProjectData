namespace EnteringProjectData.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompanyName {  get; set; }
        public string ExecutingCompanyName { get; set; }
        public List<Employee> Employees { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int Priority { get; set; }
        public Project() 
        { 
            ProjectId = Guid.NewGuid();
            Employees = new List<Employee>();
        }
        public bool AddEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
                return true;
            }
            return false;
        }

    }
}
