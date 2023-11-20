using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// AddPooledDbContextFactory allows us to create DbContext and pooled instances for reuse
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandsConStr")));

builder.Services.AddGraphQLServer()
    .AddQueryType<GQuery>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

builder.Configuration.GetConnectionString("");

var app = builder.Build();

app.UseWebSockets();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapGraphQL());

// app.MapGet("/", () => "Hello World!");

app.UseGraphQLVoyager(new GraphQLVoyagerOptions() { GraphQLEndPoint = "/graphql", Path ="/graphql-voyager" });

app.Run();
