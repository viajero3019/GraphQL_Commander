using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using System.Linq;

namespace CommanderGQL.GraphQL
{
    public class GQuery
    {
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}