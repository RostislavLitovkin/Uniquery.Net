﻿using GraphQL.Client.Http;
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
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { id_eq = id };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
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
        /// await Uniquery.RmrkV2.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { collection = new { id_eq = collectionId } };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.NftListByName("shape");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { name_containsInsensitive = name };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftListByMetadataId(
            string metadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { meta = new { id_eq = metadataId } };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Collection metadata id
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftListByCollectionMetadataId(
            string collectionMetadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { collection = new { meta = new { id_eq = collectionMetadataId } } };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftListByOwner(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { currentOwner_eq = address };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.NftList(forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Nft>> NftList(
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10)
        {
            var filter = new { };

            var nfts = await RmrkV2NftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                emotesLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns all events
        /// <example>
        /// <code>
        /// await Uniquery.RmrkV2.EventList();
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Event>> EventList(
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { };

            var events = await RmrkV2EventService.GetEventEntitiesAsync(
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
        /// await Uniquery.RmrkV2.EventListByAddress("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Event>> EventListByAddress(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { caller_eq = address };

            var events = await RmrkV2EventService.GetEventEntitiesAsync(
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
        /// await Uniquery.RmrkV2.EventListByCollectionId("C4F63647002B182C0E-NEON");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Event>> EventListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { collection = new { id_eq = collectionId } } };

            var events = await RmrkV2EventService.GetEventEntitiesAsync(
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
        /// await Uniquery.RmrkV2.EventListByInteraction(Uniquery.RmrkV2Interaction.BUY);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Event>> EventListByInteraction(
            RmrkV2Interaction interaction,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { interaction_eq = interaction };

            var events = await RmrkV2EventService.GetEventEntitiesAsync(
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
        /// await Uniquery.RmrkV2.EventListByNftId("18641451-C4F63647002B182C0E-WOLF-WOLF_2-0000000000000002");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<RmrkV2Event>> EventListByNftId(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC")
        {
            var filter = new { nft = new { id_eq = id } };

            var events = await RmrkV2EventService.GetEventEntitiesAsync(
                    filter,
                    limit,
                    offset,
                    orderBy
                    );

            return events;
        }
    }
}
