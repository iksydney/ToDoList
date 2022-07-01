using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoApplication.Components
{
    public class SearchList : ViewComponent
    {
        private readonly ITaskService _todo;

        public SearchList(ITaskService todo)
        {
            _todo = todo;
        }

        public IViewComponentResult Invoke()
        {

            var todo = new Task();
            return View(todo);
        }
    }
}
