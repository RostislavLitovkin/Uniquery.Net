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
        /// await Uniquery.RmrkV2.CollectionById("ccae98d28cd76f9015-GRAFF");
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

        /// <summary>
        /// returns collections where issuer (creator) is equal to provided address
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.CollectionListByIssuer("F5DaGLPBkroG9tYGZPaaAaQWqzkNgJgjrz17FAmk1EVNKn9");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Collection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { issuer_eq = issuerAddress };

            var collections = await RmrkV2CollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }

        /// <summary>
        /// returns collections where name contains provided name
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.CollectionListByName("African Arts & Culture");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Collection>> CollectionListByName(
            string collectionName,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { name_containsInsensitive = collectionName };

            var collections = await RmrkV2CollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }


        /// <summary>
        /// returns collections where owner is equal to provided address
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.CollectionListByOwner("F5DaGLPBkroG9tYGZPaaAaQWqzkNgJgjrz17FAmk1EVNKn9");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Collection>> CollectionListByOwner(
            string owner,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { currentOwner_eq = owner };

            var collections = await RmrkV2CollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }


        public static async Task<RmrkV2Nft> NftById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { id_eq = id };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                emotesLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts[0];
        }
    }
}
