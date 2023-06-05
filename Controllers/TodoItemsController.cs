using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
  private readonly ITodoRepo todoRepo;
  private readonly ILogger<TodoItemsController> _logger;
  public TodoItemsController(TodoRepo repo, ILogger<TodoItemsController> logger)
  {
    todoRepo = repo;
    _logger = logger;
  }

  // GET: api/TodoItems
  [HttpGet]
  public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
  {
    return await todoRepo.GetTodoItems();
  }

  // GET: api/TodoItems/5
  [HttpGet("{id}")]
  public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
  {
    return await todoRepo.GetTodoByID(id);
  }

  //   // PUT: api/TodoItems/5
  //   // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  //   [HttpPut("{id}")]
  //   public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
  //   {
  //     if (id != todoItem.Id)
  //     {
  //       return BadRequest();
  //     }

  //     _context.Entry(todoItem).State = EntityState.Modified;

  //     try
  //     {
  //       await _context.SaveChangesAsync();
  //     }
  //     catch (DbUpdateConcurrencyException)
  //     {
  //       if (!TodoItemExists(id))
  //       {
  //         return NotFound();
  //       }
  //       else
  //       {
  //         throw;
  //       }
  //     }

  //     return NoContent();
  //   }

  // POST: api/TodoItems
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
  {
    var item = await todoRepo.CreateTodo(todoItem);
    if (item == null)
    {
      return Problem("Entity set 'TodoContext.TodoItems'  is null.");
    }

    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
  }

  //   // DELETE: api/TodoItems/5
  //   [HttpDelete("{id}")]
  //   public async Task<IActionResult> DeleteTodoItem(long id)
  //   {
  //     if (_context.TodoItems == null)
  //     {
  //       return NotFound();
  //     }
  //     var todoItem = await _context.TodoItems.FindAsync(id);
  //     if (todoItem == null)
  //     {
  //       return NotFound();
  //     }

  //     _context.TodoItems.Remove(todoItem);
  //     await _context.SaveChangesAsync();

  //     return NoContent();
  //   }

  //   private bool TodoItemExists(long id)
  //   {
  //     return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
  //   }
}
