using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net;

namespace Uniquery
{
    public static class Rmrk
    {
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/rubick/graphql", new NewtonsoftJsonSerializer()
        );

        public static async Task<RmrkCollection> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new RmrkCollectionFilter { id_eq = id };
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
    };
}