using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModel
{
    public class viewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Task")]
        public string task { get; set; }
        public string createdDate { get; set; }
        public string dueDate { get; set; }
    }
}