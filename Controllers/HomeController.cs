using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskvariable;

        public HomeController(ILogger<HomeController> logger, ITaskService taskvariable)
        {
            _logger = logger;
            _taskvariable = taskvariable;

        }
        public IActionResult Index()
        {
            var tasks = _taskvariable.GetAllRecords();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(Task obj)
        {
            
            _taskvariable.CreateTask(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var editView = _taskvariable.GetTaskById(id);
            return View(editView);
        }
        public IActionResult RemoveAll()
        {
            _taskvariable.DeleteAllRecord();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var deleteView = _taskvariable.GetTaskById(id);
            return View(deleteView);
        }
        public IActionResult DeleteById(int id)
        {
            _taskvariable.DeleteRecordbyId(id);
            return RedirectToAction("Index");
        }

        
       
        public IActionResult Update(Task obj)
        {
            _taskvariable.UpdateRecord(obj);
            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Search(Task search)
        {
            var result = _taskvariable.SearchRecord(search.task);
            return View(result);
        }

        //[HttpGet]

        //public IActionResult Search()
        //{
        //   // var result = _taskvariable.SearchRecord();
        //    return View();
        //}
    }
}
