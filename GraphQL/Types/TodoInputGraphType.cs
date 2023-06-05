using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace TodoApi.GraphQL.Types
{
  public class TodoInputGraphType : InputObjectGraphType
  {
    public TodoInputGraphType()
    {
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<BooleanGraphType>("isCompleted");
    }
  }
}