

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ToDoList.Models;
using ToDoList.Repository;
using ToDoList.ViewModel;

namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository _repo;
        private readonly IConfiguration _config;

        public TaskService(IRepository repo)
        {
            _repo = repo;
        }
        #region(Create Task)
        public bool CreateTask(Task obj)
        {
            var createdDate = DateTime.Now.ToShortDateString();
            var dueDate = obj.dueDate.ToString();
            var statement = $"INSERT INTO ToDo VALUES('{obj.task}', '{obj.dueDate}', '{createdDate}')";
            return _repo.ExecuteQuery(statement);
            
        }
        #endregion

        #region Delete All Record
        public bool DeleteAllRecord()
        {
            string statement = "TRUNCATE TABLE ToDo";
            return _repo.ExecuteQuery(statement);
        }
        #endregion

        public bool DeleteRecordbyId(int id)
        {
            var statement = $"DELETE FROM ToDo WHERE id={id}";
            return _repo.ExecuteQuery(statement);
        }

        #region(Get All Records)
        public List<viewModel> GetAllRecords()
        {
            var res = _repo.FetchDataFromDB("SELECT * FROM ToDo");
            try
            {
                if (res.HasRows)
                {
                    var records = new List<viewModel>();
                    while (res.Read())
                    {
                        records.Add(new viewModel()
                        {
                            Id = (int)res["id"],
                            task = res["task"].ToString(),
                            createdDate = res["CreatedDate"].ToString(),
                            dueDate = res["DueDate"].ToString(),   
                        });
                    }
                    return records;
                }
                else
                {
                    return new List<viewModel>();
                }
            }
            finally
            {
            }
        }
        #endregion

        #region Get Task By ID
        public Task GetTaskById(int id)
        {
            var statement = $"SELECT * FROM ToDo WHERE id= {id}";
             var dataValue = _repo.FetchDataFromDB(statement);
            try
            {
                if (dataValue.HasRows)
                {
                    var result = new Task();
                    while (dataValue.Read())
                    {
                        result.Id = (int)dataValue["id"];
                        result.task = dataValue["task"].ToString();
                        result.dueDate =Convert.ToDateTime(dataValue["DueDate"].ToString());

                    }
                    return result;
                }
                else
                {
                    return new Task();
                }
            }
            finally
            {

            }
        }
        #endregion

        public List<Task> SearchRecord(string search)
        {
            var statement = $"SELECT * FROM ToDo WHERE task LIKE '%{search}%'";
            var command = _repo.FetchDataFromDB(statement);
            
            var result = new List<Task>();
            if(command != null)
            {
                while(command.Read())
                {
                    result.Add(
                        new Task()
                        {
                            Id = Convert.ToInt32(command["id"].ToString()),
                            task = command["task"].ToString(),
                        });
                }
            }
            return result;
        }

        public bool UpdateRecord(Task obj)
        {
            var dueDateString = obj.dueDate.ToShortDateString();
            var statement = $"UPDATE ToDo SET task = '{obj.task}', DueDate = '{dueDateString}' WHERE id = {obj.Id}";
            return _repo.ExecuteQuery(statement);
        }
    }
}
