using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Uniquery
{
    public static class Glmr
    {
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/click/v/002/graphql", new NewtonsoftJsonSerializer()
        );

        // COLLECTIONS FUNCTIONS

        /// <summary>
        /// Returns collection by id.
        /// <exception>
        /// <para>
        /// Throws Exception if no collection with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.CollectionById("0xb6e9e605aa159017173caa6181c522db455f6661");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrCollection>> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { id_eq = id };

            var collections = await GlmrCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections;
        }

        /// <summary>
        /// returns collections where name contains provided name
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.CollectionListByName("Shaban");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrCollection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { issuer_eq = issuerAddress };

            var collections = await GlmrCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections;
        }

        /// <summary>
        /// returns collections where name contains provided name
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.CollectionListByName("Shaban");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrCollection>> CollectionListByName(
            string collectionName,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { name_containsInsensitive = collectionName };

            var collections = await GlmrCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections;
        }

        /// <summary>
        /// returns collections where owner is equal to provided address
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.CollectionListByOwner("D5QWdFqn5FUaGFvgKGKtx8X4z1PVuXo8ZoGdhhCwc1vGJ3e");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrCollection>> CollectionListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { currentOwner_eq = ownerAddress };

            var collections = await GlmrCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            if (!collections.Any())
            {
                throw new Exception("No collection found.");
            }

            return collections;
        }

        // NFT FUNCTIONS

        /// <summary>
        ///  returns NFT by id
        /// <exception>
        /// <para>
        /// Throws Exception if no nft with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftById("18636665-C4F63647002B182C0E-WOLF4-WOLF4_2-0000000000000002")
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { id_eq = id };
            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs where collection id is equal to provided id
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { id_eq = collectionId };
            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftListByName("shape");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { name_containsInsensitive = name };
            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftListByMetadataId(
            string metadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { meta = new { id_eq = metadataId } };
            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Collection metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftListByCollectionMetadataId(
            string collectionMetadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { collection = new { meta = new { id_eq = collectionMetadataId } } };

            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address (currentOwner)
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftListByOwner(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { currentOwner_eq = address };

            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.NftList(forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrNft>> NftList(
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int nftsLimit = 10)
        {
            var filter = new { };

            var nfts = await GlmrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                eventsLimit,
                nftsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts;
        }

        // EVEVNT FUNCTIONS

        /// <summary>
        /// returns all events
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.EventList();
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrEvent>> EventList(
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { };

            var events = await GlmrEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return events;
        }

        /// <summary>
        ///  returns events by address (caller)
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.EventListByAddress("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrEvent>> EventListByAddress(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { caller_eq = address };

            var events = await GlmrEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return events;
        }

        /// <summary>
        /// returns events by collection id
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.EventListByCollectionId("C4F63647002B182C0E-NEON");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrEvent>> EventListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { collection = new { id_eq = collectionId } } };

            var events = await GlmrEventService.GetEventEntitiesAsync(
                    filter,
                    limit,
                    offset,
                    orderBy
                    );

            return events;
        }

        /// <summary>
        /// returns events by interaction
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.EventListByInteraction(Uniquery.GlmrInteraction.Buy);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrEvent>> EventListByInteraction(
            GlmrInteraction interaction,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { interaction_eq = interaction };

            var events = await GlmrEventService.GetEventEntitiesAsync(
                    filter,
                    limit,
                    offset,
                    orderBy
                    );

            return events;
        }

        /// <summary>
        /// returns events by nft id
        /// <example>
        /// <code>
        /// await Uniquery.Glmr.EventListByNftId("18641451-C4F63647002B182C0E-WOLF-WOLF_2-0000000000000002");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<GlmrEvent>> EventListByNftId(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { id_eq = id } };

            var events = await GlmrEventService.GetEventEntitiesAsync(
                    filter,
                    limit,
                    offset,
                    orderBy
                    );

            return events;
        }
    }
}
