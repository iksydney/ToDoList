using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Task")]
        public string task { get; set; }
        [DisplayName("Due Date")]
        public DateTime dueDate { get; set; }
        public DateTime createdDate { get; set; }
       // [DisplayName("Created Date")]
       // public DateTime createdDate { get; set; }
    }
}
