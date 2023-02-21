using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project2Section1Group6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Section1Group6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Initialize instance of object
        private TaskContext myContext { get; set; }
                                                             // Pass In data from context file
        public HomeController(ILogger<HomeController> logger, TaskContext pointlessName)
        {
            _logger = logger;

            // Lock-in instance of object
            myContext = pointlessName;
        }
        // Index (HomePage) Direct
        public IActionResult Index()
        {
            return View();
        }
        // Privacy Direct
        public IActionResult Privacy()
        {
            return View();
        }

        //Create Task Page Direct
        [HttpGet]
        public IActionResult CreateTasks()
        {
            return View();
        }
        //Return data for database from Create Task Page
        [HttpPost]
        public IActionResult CreateTasks()
        {
            return View();
        }

        //Quadrant Page Direct
        [HttpGet]
        public IActionResult Quadrants()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int localID) // Edit where where the ID is 
        {
            ViewBag.Cat = myContext.Categories.ToList();

            var application = myContext.Responses.Single(x => x.ForeignID == localID);

            return View("CreateTask", application);
        }
        [HttpPost]
        public IActionResult Edit(Task t) // Change Database values
        {
            myContext.Update(t);
            myContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult Delete(int localID) // remove data entry where ID is
        {
            var application = myContext.Responses.Single(x => x.ForeignID == localID);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(Task t) // remove data entry where Movie ID is
        {
            myContext.Responses.Remove(t);
            myContext.SaveChanges();


            return RedirectToAction("Quadrants");
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
