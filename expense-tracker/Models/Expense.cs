using System.ComponentModel.DataAnnotations;

namespace expense_tracker.Models;


public class Expense {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}