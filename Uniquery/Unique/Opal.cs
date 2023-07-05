using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Uniquery
{
	public class Opal
	{
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://api-opal.uniquescan.io/v1/graphql", new NewtonsoftJsonSerializer()
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
        /// await Uniquery.Opal.CollectionById(1850);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<UniqueCollection> CollectionById(
            int id,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection_id = new { _eq = id } };

            var collections = await UniqueCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections[0];
        }


        public static async Task<List<UniqueCollection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0)
        {
            return await CollectionListByOwner(issuerAddress, limit, offset);
        }

        public static async Task<List<UniqueCollection>> CollectionListByName(
            string name,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { name = new { _eq = name } };

            var collections = await UniqueCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset
                );

            return collections;
        }

        public static async Task<List<UniqueCollection>> CollectionListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { owner = new { _eq = ownerAddress } };

            var collections = await UniqueCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset
                );

            return collections;
        }
    }
}

