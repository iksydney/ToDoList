/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ToDoList.Models;
*//*

namespace ToDoList.Controllers
{
    public class HomeControlleVoidr : Controller
    {
        private readonly ILogger<HomeControlleVoidr> _logger;
        private readonly ITaskService _taskvariable;

        public HomeControlleVoidr(ILogger<HomeControlleVoidr> logger, ITaskService task)
        {
            _taskvariable = task;
            _logger = logger;
        }

        public IActionResult Index()
        {*//*
           // var tasks = _taskvariable.GetAllTask();
            //return View(tasks);
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
        public IActionResult Create()
        {
            return View();
        }
        *//*[HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
           var editView = _taskvariable.getTaskById(id);
            return View(editView);
        }
        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if(task == null)
            {
                return NotFound();
            }
            _taskvariable.updateTask(task);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult DeleteById(int id)
        {
            _taskvariable.removeTaskById(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveAllTask()
        {
            _taskvariable.removeAllTask();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(Task obj)
        {
            _taskvariable.AddTask(obj);
            return RedirectToAction("Index");
        }*//*
    }
}
*/