using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;

namespace Uniquery
{
    public class Shiden
    {
        private const string NETWORK_ID = "336";

        /// <summary>
        ///  returns NFT by id
        /// <exception>
        /// <para>
        /// Throws Exception if no nft with the same id was found.
        /// </para>
        /// </exception>
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftById("18636665-C4F63647002B182C0E-WOLF4-WOLF4_2-0000000000000002")
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<OnFinalityNft> NftById(
            string id,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { id = new { equalTo = id }, collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
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

        /// <summary>
        /// returns NFTs where collection id is equal to provided id
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<OnFinalityNft>> NftListByCollectionId(
            string collectionId,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collectionId = new { equalTo = collectionId }, collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftListByName("shape");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<OnFinalityNft>> NftListByName(
            string name,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { metadata = new { name = new { includesInsensitive = name } }, collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<OnFinalityNft>> NftListByMetadataId(
            string metadataId,
            int limit = 25,
            int offset = 0)
        {
            var filter = new { metadata = new { id = new { equalTo = metadataId } }, collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<OnFinalityNft>> NftListByOwner(
            string ownerAddress,
            int limit = 25,
            int offset = 0)
        {
            string pubkey = ownerAddress.StartsWith("0x") ? ownerAddress : Utils.Bytes2HexString(Utils.GetPublicKeyFrom(ownerAddress)).ToLower();

            var filter = new { currentOwner = new { equalTo = pubkey }, collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.Shiden.NftList();
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<OnFinalityNft>> NftList(
            int limit = 25,
            int offset = 0)
        {
            var filter = new { collection = new { networkId = new { equalTo = NETWORK_ID } } };

            var nfts = await OnFinalityNftService.GetNftEntitiesAsync(
                filter,
                limit,
                offset
                );

            return nfts;
        }
    }
}