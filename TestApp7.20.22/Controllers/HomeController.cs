using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestApp7._20._22.Models;
using TestApp7._20._22.Services;
using TestApp7._20._22.ViewModel;

namespace TestApp7._20._22.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee employee;

        public HomeController(ILogger<HomeController> logger, IEmployee employee)
        {
            _logger = logger;
            this.employee = employee;
        }

        public IActionResult Index()
        {
            //.net 6
            //HomeViewModel homeViewModel = new();
            HomeViewModel homeViewModel = new HomeViewModel();

            var listOfEmployees = employee.GetEmployees();
            homeViewModel.Employees = listOfEmployees.ToList();
            return View(homeViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            var myemp = employee.GetEmployee(id);

            return View(myemp);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee newemp)
        {
            if (ModelState.IsValid)
            {
                var newempreg = employee.AddEmployee(newemp);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Update(Employee newemp)
        {
            if (ModelState.IsValid)
            {
                var updateempreg = employee.UpdateEmployee(newemp);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public IActionResult Remove(int id)
        {
            employee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
