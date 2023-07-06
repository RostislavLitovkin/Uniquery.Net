using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Uniquery
{
	public class Basilisk
	{
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/snekk/graphql", new NewtonsoftJsonSerializer()
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
        /// await Uniquery.Basilisk.CollectionById("1");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<BasiliskCollection> CollectionById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { id_eq = id };

            var collections = await BasiliskCollectionService.GetCollectionEntitiesAsync(
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
        /// await Uniquery.Basilisk.CollectionListByIssuer("bXj4uMHTrBtVfmVMDpQ1AyUUNbnvLaRPcBDVTeLffL2h2U3KE");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskCollection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { issuer_eq = issuerAddress };

            var collections = await BasiliskCollectionService.GetCollectionEntitiesAsync(
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
        /// await Uniquery.Basilisk.CollectionListByName("lin");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskCollection>> CollectionListByName(
            string collectionName,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { name_containsInsensitive = collectionName };

            var collections = await BasiliskCollectionService.GetCollectionEntitiesAsync(
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
        /// await Uniquery.Basilisk.CollectionListByOwner("bXj4uMHTrBtVfmVMDpQ1AyUUNbnvLaRPcBDVTeLffL2h2U3KE");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskCollection>> CollectionListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC")
        {
            var filter = new { currentOwner_eq = ownerAddress };

            var collections = await BasiliskCollectionService.GetCollectionEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy
                );

            return collections;
        }

        /// <summary>
        ///  returns NFT by id
        /// <exception>
        /// <para>
        /// Throws Exception if no nft with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftById("4155379122-4");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<BasiliskNft> NftById(
            string id,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { id_eq = id };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
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
        /// await Uniquery.Basilisk.NftListByCollectionId("4155379122");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { collection = new { id_eq = collectionId } };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftListByName("Snek", forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { name_containsInsensitive = name };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftListByMetadataId("ipfs://ipfs/bafkreiaig3izwq2de7hiikzcfbfg4ax3xpofsxmkgb6p63xtan2k56x7vi");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftListByMetadataId(
            string metadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { meta = new { id_eq = metadataId } };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Collection metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiaig3izwq2de7hiikzcfbfg4ax3xpofsxmkgb6p63xtan2k56x7vi");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftListByCollectionMetadataId(
            string collectionMetadataId,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { collection = new { meta = new { id_eq = collectionMetadataId } } };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftListByOwner("bXkmHMVWgX5k8JkKGqrAw1RCso6abY2U9Q5E12vvYZQxeNf7S");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftListByOwner(
            string address,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { currentOwner_eq = address };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.Basilisk.NftList(forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<BasiliskNft>> NftList(
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10)
        {
            var filter = new { };

            var nfts = await BasiliskNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset,
                orderBy,
                forSale,
                eventsLimit,
                offersLimit
                );

            return nfts;
        }
    }
}

