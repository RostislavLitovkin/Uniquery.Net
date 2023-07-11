using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniquery
{
    public static class Movr
    {
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/antick/v/001-rc0/graphql", new NewtonsoftJsonSerializer()
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
        /// await Uniquery.Movr.CollectionById("7EA1DCF47E98A25067-CAVE");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<MovrCollection> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { id_eq = id };

            var collections = await MovrCollectionService.GetCollectionEntitiesAsync(
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
        /// <example>
        /// <code>
        /// await Uniquery.Movr.CollectionListByIssuer("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrCollection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { issuer_eq = issuerAddress };

            var collections = await MovrCollectionService.GetCollectionEntitiesAsync(
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
        /// await Uniquery.Movr.CollectionListByName("Shaban");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrCollection>> CollectionListByName(
            string collectionName,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { name_containsInsensitive = collectionName };

            var collections = await MovrCollectionService.GetCollectionEntitiesAsync(
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
        /// await Uniquery.Movr.CollectionListByOwner("D5QWdFqn5FUaGFvgKGKtx8X4z1PVuXo8ZoGdhhCwc1vGJ3e");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrCollection>> CollectionListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { currentOwner_eq = ownerAddress };

            var collections = await MovrCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

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
        /// await Uniquery.Movr.NftById("18636665-C4F63647002B182C0E-WOLF4-WOLF4_2-0000000000000002")
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<MovrNft> NftById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { id_eq = id };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            if (!nfts.Any())
            {
                throw new Exception("No nft found.");
            }

            return nfts[0];
        }

        /// <summary>
        /// returns NFTs where collection id is equal to provided id
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { collection = new { id_eq = collectionId } };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftListByName("shape");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { name_containsInsensitive = name };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftListByMetadataId(
            string metadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { metadata_eq = metadataId };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Collection metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftListByCollectionMetadataId(
            string collectionMetadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { collection = new { metadata_eq = collectionMetadataId } };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftListByOwner(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { currentOwner_eq = address };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.Movr.NftList(forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrNft>> NftList(
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10)
        {
            var filter = new { };

            var nfts = await MovrNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit
                );

            return nfts;
        }


        // EVENTS FUNCTIONS 

        /// <summary>
        /// returns all events
        /// <example>
        /// <code>
        /// await Uniquery.Movr.EventList();
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrEvent>> EventList(
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { };

            var events = await MovrEventService.GetEventEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return events;
        }

        /// <summary>
        ///  returns events by address
        /// <example>
        /// <code>
        /// await Uniquery.Movr.EventListByAddress("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrEvent>> EventListByAddress(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { caller_eq = address };

            var events = await MovrEventService.GetEventEntitiesAsync(
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
        /// await Uniquery.Movr.EventListByCollectionId("C4F63647002B182C0E-NEON");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrEvent>> EventListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { collection = new { id_eq = collectionId } } };

            var events = await MovrEventService.GetEventEntitiesAsync(
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
        /// await Uniquery.Movr.EventListByInteraction(Uniquery.MovrInteraction.BUY);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrEvent>> EventListByInteraction(
            MovrInteraction interaction,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { interaction_eq = interaction };

            var events = await MovrEventService.GetEventEntitiesAsync(
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
        /// await Uniquery.Movr.EventListByNftId("18641451-C4F63647002B182C0E-WOLF-WOLF_2-0000000000000002");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<MovrEvent>> EventListByNftId(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { id_eq = id } };

            var events = await MovrEventService.GetEventEntitiesAsync(
                    filter,
                    limit,
                    offset,
                    orderBy
                    );

            return events;
        }
    }
}
