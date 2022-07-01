using System.Collections.Generic;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList.Services
{
    public interface ITaskService
    {
        public List<viewModel> GetAllRecords();
        public Task GetTaskById(int taskId);
        public bool UpdateRecord(Task obj);
        public bool DeleteAllRecord();
        public bool DeleteRecordbyId(int id);
        public List<Task> SearchRecord(string search);
        public bool CreateTask(Task task);
    }
}
