using AppSqlReadOnly.Lab.Dal;
using AppSqlReadOnly.Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Employees()
        {
            var employees = await _unitOfWork.EmployeesRepository.GetAllAsync();
            return View(employees);
        }
        public async Task<IActionResult> EmployeeById(int id)
        {
            var employee = await _unitOfWork.EmployeesRepository.GetAsync(id);
            return View(employee);
        }
        public async Task<IActionResult> EmployeesByCity(string city)
        {
            var employeeByCity = await _unitOfWork.EmployeesRepository.GetByCityAsync(city);
            return View(employeeByCity);
        }

        public IActionResult Index()
        {
            return View();
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
