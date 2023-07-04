using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniquery
{
    public static class RmrkV2
    {
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/marck/v/v2/graphql", new NewtonsoftJsonSerializer()
        );


        public static async Task<RmrkCollection> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { id_eq = id };

            var collections = await RmrkCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections[0];
        }
    }
}
