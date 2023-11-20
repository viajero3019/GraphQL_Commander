using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandsConStr")));

builder.Services.AddGraphQLServer().AddQueryType<GQuery>();

builder.Configuration.GetConnectionString("");

var app = builder.Build();

app.UseEndpoints(endpoints => endpoints.MapGraphQL());

// app.MapGet("/", () => "Hello World!");

app.Run();
