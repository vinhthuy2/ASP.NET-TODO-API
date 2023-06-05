using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TodoApi.Models;
namespace TodoApi.Repository;

public interface ITodoRepo
{
  Task<List<TodoItem>> GetTodoItems();
  Task<TodoItem> GetTodoByID(long id);
  Task<TodoItem> CreateTodo(TodoItem id);
}

