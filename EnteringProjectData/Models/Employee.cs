namespace EnteringProjectData.Models
{
    public class Employee
    {
        //public Guid EmployeeId { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
        public Employee(int employeeID)
        {
            //EmployeeId = Guid.NewGuid();
            EmployeeID = employeeID;
            Projects = new List<Project> ();
        }

        public bool AddInProject(Project project)
        {
            if(!Projects.Contains(project))
            {
                Projects.Add(project);
                return true;
            }
            return false;
        }
    }
}
