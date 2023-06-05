using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Autofac;
using GraphQL;
using GraphQL.Types;
using GraphQL.Server.Ui.Altair;
using TodoApi.Repository;
using TodoApi.GraphQL;
using TodoApi.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddScoped<TodoRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQL(builder =>
{
  builder.ConfigureExecutionOptions(options => options.EnableMetrics = true)
  .AddSystemTextJson()
  .AddErrorInfoProvider(options =>
  {
    options.ExposeExceptionDetails = true;
  });
});

builder.Services.AddScoped<TodoObject>();
builder.Services.AddScoped<TodoInputGraphType>();
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<ISchema, TodoSchema>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseGraphQL<ISchema>();
app.UseGraphQLGraphiQL("/graphql/ui");
app.UseGraphQLAltair("/graphql");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
