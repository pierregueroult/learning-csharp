using Microsoft.EntityFrameworkCore;
using expense_tracker.Models;

namespace expense_tracker.Data;

public class ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }
}