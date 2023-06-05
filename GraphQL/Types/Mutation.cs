using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.GraphQL.Types
{
  public class Mutation : ObjectGraphType
  {
    /*
    mutation {
        newTodo( todo: {
            name: "1st todo"
            isCompleted: false
        }) {
            id, name, isCompleted
        }
    }
    */
    public Mutation(TodoRepo repo)
    {
      Name = nameof(Mutation);

      Field<TodoObject>("newTodo")
          .Description("create new todo")
          .Arguments(
            new QueryArguments(
                new QueryArgument<NonNullGraphType<TodoInputGraphType>>
                {
                  Name = "todo"
                }))
          .ResolveAsync(async ctx => await repo.CreateTodo(ctx.GetArgument<TodoItem>("todo", null)));
    }
  }
}