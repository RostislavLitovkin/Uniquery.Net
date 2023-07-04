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

        /// <summary>
        /// Returns collection by id.
        /// <exception>
        /// <para>
        /// Throws Exception if no collection with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.CollectionById("7EA1DCF47E98A25067-CAVE");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<RmrkV2Collection> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { id_eq = id };

            var collections = await RmrkV2CollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                Console.WriteLine("No collection found.");
                throw new Exception("No collection found.");
            }

            return collections[0];
        }
    }
}
