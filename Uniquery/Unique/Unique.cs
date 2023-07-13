using System;
using System.Net;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Substrate.NetApi;

namespace Uniquery
{
	public class Unique
	{
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://api-unique.uniquescan.io/v1/graphql", new NewtonsoftJsonSerializer()
        );

        const int SS58_PREFIX = 7391;

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
            var filter = new { owner = new { _eq = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(ownerAddress), SS58_PREFIX) } };

            var collections = await UniqueCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset
                );

            return collections;
        }

        public static async Task<UniqueNft> NftById(
            int id,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { token_id = new { _eq = id } };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts[0];
        }

        public static async Task<List<UniqueNft>> NftListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { owner = new { _eq = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(ownerAddress), SS58_PREFIX) } };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        public static async Task<List<UniqueNft>> NftListByCollectionId(
            int collectionId,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection_id = new { _eq = collectionId } };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        public static async Task<List<UniqueNft>> NftListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection_owner = new { _eq = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(issuerAddress), SS58_PREFIX) } };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        public static async Task<List<UniqueNft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection_name = new { _eq = name } };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        public static async Task<List<UniqueNft>> NftList(
            int limit = 25,
            int offset = 0)
        {
            var filter = new { };

            var nfts = await UniqueNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        // Does not exist
        /*public static async Task<List<UniqueNft>> NftListByMetadataId(
            string issuerAddress,
            int limit = 25,
            int offset = 0)
        {*/

        /*public static async Task<List<UniqueNft>> NftListByCollectionMetadataId(
            string issuerAddress,
            int limit = 25,
            int offset = 0)
        {*/

        public static async Task<List<UniqueEvent>> EventList(
            int limit = 25,
            int offset = 0)
        {
            var filter = new { };

            var events = await UniqueEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset
                );

            return events;
        }


        // Does not exist
        /*public static async Task<List<UniqueEvent>> EventListByAddress(
            int limit = 25,
            int offset = 0)*/

        /*public static async Task<List<UniqueEvent>> EventListByInteraction(
            int limit = 25,
            int offset = 0)*/

        // The filter in GraphQL is broken... (already issued in telegram)
        /*public static async Task<List<UniqueEvent>> EventListByCollectionId(
            int collectionId,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection_id = new { _eq = collectionId } };

            var events = await UniqueEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset
                );

            return events;
        }*/

        // The filter in GraphQL is broken... (already issued in telegram)
        /*public static async Task<List<UniqueEvent>> EventListByTokenId(
            int collectionId,
            int tokenId,
            int limit = 25,
            int offset = 0)
        {
            var filter = new
            {
                _and = new object[2] {
                    new { collection_id = new { _eq = collectionId } },
                    new { token_id = new { _eq = collectionId } }
                }
            };

            var events = await UniqueEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset
                );

            return events;
        }*/
    }
}

