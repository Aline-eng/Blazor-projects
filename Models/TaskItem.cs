using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? DueDate { get; set; }
    public Priority Priority { get; set; } = Priority.Medium;
}

public enum Priority
{
    Low,
    Medium,
    High
}
}