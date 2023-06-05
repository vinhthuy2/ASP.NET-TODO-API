using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TodoApi.Repository;
using TodoApi.Models;
using GraphQL;

namespace TodoApi.GraphQL.Types;

public class Query : ObjectGraphType<object>
{
  public Query(TodoRepo TodoRepo)
  {
    Name = "Queries";
    Description = "The base query for all the entities in our object graph.";

    Field<TodoObject>("todo")
    .Description("get todo by id")
    .Arguments(
      new QueryArguments(
        new QueryArgument<NonNullGraphType<IdGraphType>>
        {
          Name = "id",
          Description = "Todo's ID"
        }))
    .ResolveAsync(async ctx => await TodoRepo.GetTodoByID(ctx.GetArgument<int>("id", 0)));

    Field<ListGraphType<TodoObject>>("todos").Description("get all todos")
    .ResolveAsync(async ctx => await TodoRepo.GetTodoItems());
  }
}
