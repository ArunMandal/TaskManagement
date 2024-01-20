using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Status { get; set; }

    }
}
