using expense_tracker.Data;
using expense_tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace expense_tracker.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpensesController(ExpenseDbContext context) : ControllerBase 
{
    private readonly ExpenseDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
    {
        return await _context.Expenses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(int id)
    {
       var expense = await _context.Expenses.FindAsync(id);
       return expense is not null ? Ok(expense) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense(Expense expense) {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(int id, Expense expense) {
        if (id != expense.Id) return BadRequest();

        _context.Entry(expense).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id) {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense is null) return NotFound();

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}