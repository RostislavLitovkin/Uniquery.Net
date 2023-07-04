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

        /// <summary>
        /// Returns collection by id.
        /// <exception>
        /// <para>
        /// Throws Exception if no collection with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.Rmrk.CollectionById("7EA1DCF47E98A25067-CAVE");
        /// </code>
        /// </example>
        /// </summary>
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

        /// <summary>
        /// returns collections where issuer (creator) is equal to provided address
        /// <exception>
        /// <example>
        /// <code>
        /// await Uniquery.Rmrk.CollectionListByIssuer("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkCollection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { issuer_eq = issuerAddress };

            var collections = await RmrkCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }

        /// <summary>
        /// returns collections where name contains provided name
        /// <exception>
        /// <example>
        /// <code>
        /// await Uniquery.Rmrk.CollectionListByName("Shaban");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkCollection>> CollectionListByName(
            string collectionName,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { name_containsInsensitive = collectionName };

            var collections = await RmrkCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }

        /// <summary>
        /// returns collections where owner is equal to provided address
        /// <exception>
        /// <example>
        /// <code>
        /// await Uniquery.Rmrk.CollectionListByOwner("D5QWdFqn5FUaGFvgKGKtx8X4z1PVuXo8ZoGdhhCwc1vGJ3e");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkCollection>> CollectionListByOwner(
            string owner,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { currentOwner_eq = owner };

            var collections = await RmrkCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }
    }
}