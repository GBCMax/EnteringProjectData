using EnteringProjectData.Data;
using EnteringProjectData.Data.Models;
using EnteringProjectData.Data.Repository;
using EnteringProjectData.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        }

        public IActionResult Main(int? projectID)
        {
            if(projectID != null)
            {
                Project? project = _dbContext.Project.FirstOrDefault(p => p.ProjectId == projectID);
                if(project != null)
                {
                    return RedirectToAction("ChangeProject", project);
                }
            }

            return View(_projectRepository);
        }

        //public IActionResult AddEmployeeInProject(int projectID)
        //{
        //    Project? project = _dbContext.Project.FirstOrDefault(p => p.ProjectId == projectID);
        //    if (project != null)
        //    {
        //        return PartialView(_employeeRepository);
        //    }
        //    return BadRequest();
        //}

        //[HttpPost]
        //public IActionResult AddEmployeeInProject(EmployeeRepository _employeeRepository)
        //{

        //}

        public IActionResult ChangeProject(Project project)
        {
            return View(project);
        }

        public IActionResult ChangeEmployee(Employee employee)
        {
            return View(employee);
        }

        public IActionResult Employees(int? employeeID)
        {
            if (employeeID != null)
            {
                Employee? employee = _dbContext.Employee.FirstOrDefault(emp => emp.EmployeeID == employeeID);
                if (employee != null)
                {
                    return RedirectToAction("ChangeEmployee", employee);
                }
            }
            return View(_employeeRepository);
        }
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject([FromForm] Project project)
        {
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
	}
}
