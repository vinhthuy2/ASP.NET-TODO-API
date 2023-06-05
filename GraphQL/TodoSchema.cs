using GraphQL.Types;
using TodoApi.GraphQL.Types;

namespace TodoApi.GraphQL
{
  public class TodoSchema : Schema
  {
    public TodoSchema(IServiceProvider sp) : base(sp)
    {
      Query = sp.GetRequiredService<Query>();
      Mutation = sp.GetRequiredService<Mutation>(); ;
    }
  }
}