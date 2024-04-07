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
        private IndexViewModel _indexViewModel;
        private DBContext _dbContext;

		public HomeController(DBContext dBContext)
		{
            _dbContext = dBContext;
            _projectRepository = new ProjectRepository(dBContext);
            _employeeRepository = new EmployeeRepository(dBContext);
            _indexViewModel = new IndexViewModel(dBContext);
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

            return View(_indexViewModel);
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
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                if (project.StartDate.Date >= project.EndDate)
                {
                    ViewBag.Message = "Start date must be greater than end date!";
                    return View(project);
                }
                else
                {
                    await _projectRepository.AddProject(project);
                    ViewBag.Message = "Done";
                    return RedirectToAction("Main");
                }
            }
            return View(project);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Employees");
            }
            return View(employee);
        }

        public async Task<IActionResult> ChangeProject(int? projectID)
        {
            if (projectID != null)
            {
                Project? project = await _dbContext.Project.FirstOrDefaultAsync(x => x.ProjectId == projectID);
                if(project != null)
                return View(project);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProject(Project project)
        {
            if (ModelState.IsValid)
            {
                if (project.StartDate.Date >= project.EndDate)
                {
                    ViewBag.Message = "Start date must be greater than end date!";
                    return View(project);
                }
                else
                {
                    Project? p = await _dbContext.Project.FindAsync(project.ProjectId);
                    if (p != null)
                    {
                        _dbContext.Entry(p).CurrentValues.SetValues(project);
                        await _dbContext.SaveChangesAsync();
                        ViewBag.Message = "Done";
                        return RedirectToAction("Main");
                    }
                    ViewBag.Message = "Not found!";
                    return View(project);
                }
            }
            return View(project);
        }

        public async Task<IActionResult> ChangeEmployee(int? employeeID)
        {
            if (employeeID != null)
            {
                Employee? employee = await _dbContext.Employee.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
                if (employee != null)
                    return View(employee);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee? emp = await _dbContext.Employee.FindAsync(employee.EmployeeID);
                if (emp != null)
                {
                    _dbContext.Entry(emp).CurrentValues.SetValues(employee);
                    await _dbContext.SaveChangesAsync();
                    ViewBag.Message = "Done";
                    return RedirectToAction("Main");
                }
                ViewBag.Message = "Not found!";
                return View(employee);
                
            }
            return View(employee);
        }
        public IActionResult AddEmployeeInProject()
        {
            return View(_indexViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeInProject(int? projectID, int? employeeID)
        {
            Project? project = _dbContext.Project.FirstOrDefault(p => p.ProjectId == projectID);
            Employee? employee = _dbContext.Employee.FirstOrDefault(emp => emp.EmployeeID == employeeID);
            if (project != null && employee != null)
            {
                EmployeeProject? employeeProject = _dbContext.EmployeeProjects.FirstOrDefault(x => x.ProjectId == project.ProjectId && x.EmployeeID == employee.EmployeeID);
                if (employeeProject == null)
                {
                    await Task.Run(() => _projectRepository.AddEmployeeInProject(project, employee));
                    await _dbContext.SaveChangesAsync();
                    ViewBag.Message = "Done";
                    return RedirectToAction("Main", _projectRepository);
                }
                ViewBag.Message = "This employee already in project!";
                return View(_indexViewModel);
            }
            ViewBag.Message = "Project or employee is empty!";
            return View(_indexViewModel);
        }
    }
}
