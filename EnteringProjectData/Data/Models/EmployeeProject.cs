namespace EnteringProjectData.Data.Models
{
    public class EmployeeProject
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
