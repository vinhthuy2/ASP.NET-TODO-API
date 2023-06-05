using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TodoApi.Models;

namespace TodoApi.GraphQL.Types;

public class TodoObject : ObjectGraphType<TodoItem>
{
  public TodoObject()
  {
    Field(f => f.Id).Description("Todo's ID");
    Field(f => f.IsCompleted).Description("Todo's status");
    Field(f => f.Name).Description("Todo's title");
  }
}
