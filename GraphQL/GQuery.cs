using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace CommanderGQL.GraphQL
{
    public class GQuery
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        // public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}