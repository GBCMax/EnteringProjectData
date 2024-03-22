using EnteringProjectData.Models;
using EnteringProjectData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace EnteringProjectData.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        List<Project> _projects;
        public List<Employee> _employees;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
            Project project1 = new Project(1)
            {
                ProjectName = "Project1",
                CustomerCompanyName = "Customer1",
                ExecutingCompanyName = "Executor1",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(31),
                Priority = 1
            };
            Project project2 = new Project(2)
            {
                ProjectName = "Project2",
                CustomerCompanyName = "Customer2",
                ExecutingCompanyName = "Executor2",
                StartDate = DateTime.Now.Date.AddDays(-31),
                EndDate = DateTime.Now.Date,
                Priority = 2
            };
            _projects = new List<Project> { project1, project2 };
            Employee employee1 = new Employee(1)
            {
                FirstName = "Максим",
                SecondName = "Елисеев",
                Patronymic = "Викторович",
                Email = "maks_on_max@mail.ru"
            };
            Employee employee2 = new Employee(2)
            {
                FirstName = "Алексей",
                SecondName = "Зайцев",
                Patronymic = "Лох",
                Email = "почта алексея зайцева"
            };
            _employees = new List<Employee> { employee1, employee2 };
            project1.AddEmployee(employee1);
            project1.AddEmployee(employee2);
            project2.AddEmployee(employee1);
            employee1.AddInProject(project1);
            employee1.AddInProject(project2);
            employee2.AddInProject(project1);
        }

        public IActionResult Index(int? projectID)
        {
            IndexViewModel viewModel = new() { Projects = _projects, Employees = _employees};
            if (projectID != null)
            {
                viewModel.Projects = _projects.Where(x => x.ProjectId == projectID);
                viewModel.Employees = _projects.Where(x => x.ProjectId == projectID).SelectMany(x => x.Employees);
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            IndexViewModel viewModel = new() { Projects = _projects, Employees = _employees };
            //List<Employee> emps = _employees;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.ProjectId = Convert.ToInt32(Guid.NewGuid());
            _projects.Add(project);
            return RedirectToAction("Index");
        }
        public IActionResult Hello()
        {
            return PartialView();
        }

        public IActionResult Privacy()
		{
			return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
