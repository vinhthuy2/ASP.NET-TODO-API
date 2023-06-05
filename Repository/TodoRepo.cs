using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using TodoApi.Exceptions;

namespace TodoApi.Repository;

public class TodoRepo : ITodoRepo
{
  private TodoContext _dbContext;
  public TodoRepo(TodoContext ctx)
  {
    this._dbContext = ctx;
  }

  public async Task<TodoItem> CreateTodo(TodoItem item)
  {
    if (_dbContext.TodoItems == null)
    {
      return null;
    }
    _dbContext.TodoItems.Add(item);
    await _dbContext.SaveChangesAsync();
    return item;
  }

  public async Task<TodoItem> GetTodoByID(long id)
  {
    var todo = await _dbContext.TodoItems.FindAsync(id);
    if (todo == null)
    {
      throw new TodoNotFoundException();
    }
    return todo;
  }

  public async Task<List<TodoItem>> GetTodoItems()
  {
    if (_dbContext.TodoItems == null)
    {
      throw new TodoNotFoundException();
    }
    return await _dbContext.TodoItems.ToListAsync();
  }

  public void test()
  {
    throw new NotImplementedException();
  }
}

