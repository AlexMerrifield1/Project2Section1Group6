using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project2Section1Group6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project2Section1Group6.Controllers
{
    public class HomeController : Controller
    {
        // Initialize instance of object
        private TaskContext myContext { get; set; }
        // --------------------------------------Controller---------------------------------------
        // Pass In data from context file
        public HomeController(TaskContext pointlessName)
        {
            // Lock-in instance of object
            myContext = pointlessName;
        }
        // --------------------------------------INDEX---------------------------------------
        // Index (HomePage) Direct
        public IActionResult Index()
        {
            return View();
        }
        // -----------------------------------CREATE-TASKS------------------------------------------
        //Create Task Page Direct
        [HttpGet]
        public IActionResult CreateTasks()
        {
            ViewBag.Cat = myContext.Categories.ToList();
            return View();
        }
        //Return data for database from Create Task Page
        [HttpPost]
        public IActionResult CreateTasks(Task t)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(t);
                myContext.SaveChanges();
                return View ("Quadrants");
            }
            else //If Invalid
            {
                ViewBag.Cat = myContext.Categories.ToList();

                return View(t);
            }
        }
        // ---------------------------------QUADRANTS--------------------------------------------
        //Quadrant Page Direct
        [HttpGet]
        public IActionResult Quadrants()
        {
            return View();
        }
        // -----------------------------EDIT------------------------------------------------
        [HttpGet]
        public IActionResult Edit(int localID) // Edit where where the ID is 
        {
            ViewBag.Cat = myContext.Categories.ToList();

            var application = myContext.Tasks.Single(x => x.TaskID == localID);

            return View("CreateTask", application);
        }
        [HttpPost]
        public IActionResult Edit(Task t) // Change Database values
        {
            myContext.Update(t);
            myContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        // --------------------------------DELETE---------------------------------------------
        [HttpGet]
        public IActionResult Delete(int localID) // remove data entry where ID is
        {
            var application = myContext.Tasks.Single(x => x.TaskID == localID);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(Task t) // remove data entry where Movie ID is
        {
            myContext.Tasks.Remove(t);
            myContext.SaveChanges();
            

            return RedirectToAction("Quadrants");
        }
    }
}
