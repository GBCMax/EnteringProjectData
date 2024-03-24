using EnteringProjectData.Data;
using EnteringProjectData.Data.Models;
using EnteringProjectData.Data.Repository;
using EnteringProjectData.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace EnteringProjectData.Controllers
{
    public class HomeController : Controller
	{
        private ProjectRepository _projectRepository;
        private EmployeeRepository _employeeRepository;
        private DBContext _dbContext;

		public HomeController(DBContext dBContext)
		{
            _dbContext = dBContext;
            _projectRepository = new ProjectRepository(dBContext);
            _employeeRepository = new EmployeeRepository(dBContext);
            //FillDB();
        }

        public IActionResult Main()
        {
            return View(_projectRepository);
        }

        public IActionResult Employees()
        {
            return View(_employeeRepository);
        }
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject([FromForm] Project project)
        {
            project.Employees = new List<Employee>();
            if (ModelState.IsValid)
            {
                _projectRepository.AddProject(project);
                return RedirectToAction("Main");
            }
            return View(project);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromForm] Employee employee)
        {
            employee.Projects = new List<Project>();
            if(ModelState.IsValid)
            {
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Main");
            }
            return View(employee);
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
        //private void FillDB()
        //{
        //    Project project1 = new Project
        //    {
        //        ProjectName = "Project1",
        //        CustomerCompanyName = "Customer1",
        //        ExecutingCompanyName = "Executor1",
        //        StartDate = DateTime.Now.Date,
        //        EndDate = DateTime.Now.Date.AddDays(31),
        //        Priority = 1
        //    };
        //    Project project2 = new Project
        //    {
        //        ProjectName = "Project2",
        //        CustomerCompanyName = "Customer2",
        //        ExecutingCompanyName = "Executor2",
        //        StartDate = DateTime.Now.Date.AddDays(-31),
        //        EndDate = DateTime.Now.Date,
        //        Priority = 2
        //    };
        //    if (!_indexViewModel.Projects.Contains(project1) && !_indexViewModel.Projects.Contains(project2))
        //    {
        //        _indexViewModel.Projects.Add(project1);
        //        _indexViewModel.Projects.Add(project2);
        //    }
        //    Employee employee1 = new Employee(1)
        //    {
        //        FirstName = "Максим",
        //        SecondName = "Елисеев",
        //        Patronymic = "Викторович",
        //        Email = "maks_on_max@mail.ru"
        //    };
        //    Employee employee2 = new Employee(2)
        //    {
        //        FirstName = "Алексей",
        //        SecondName = "Зайцев",
        //        Patronymic = "Лох",
        //        Email = "почта алексея зайцева"
        //    };
        //    if (!_indexViewModel.Employees.Contains(employee1) && !_indexViewModel.Employees.Contains(employee2))
        //    {
        //        _indexViewModel.Employees.Add(employee1);
        //        _indexViewModel.Employees.Add(employee2);
        //        project1.AddEmployee(employee1);
        //        project1.AddEmployee(employee2);
        //        project2.AddEmployee(employee1);
        //    }
        //}
	}
}
