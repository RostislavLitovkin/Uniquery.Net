using System;
using System.Collections;
using System.Reflection.Metadata;

namespace Uniquery
{
    public class Universal
    {
        /// <summary>
        /// Returns collections by id.
        /// <example>
        /// <code>
        /// await Uniquery.Universal.CollectionListById("7EA1DCF47E98A25067-CAVE");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Collection>> CollectionListById(
            string id,
            int limit = 1,
            int offset = 0,
            CancellationToken token = default(CancellationToken))
        {
            List<Collection> collections = new List<Collection>();

            try
            {
                var collection = await Rmrk.CollectionById(id, limit, offset, token: token);
                collections.Add(collection);
            }
            catch
            {

            }
            try
            {
                var collection = await RmrkV2.CollectionById(id, limit, offset, token: token);
                collections.Add(collection);
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var collection = await Unique.CollectionById(iId, limit, offset, token: token);
                    collections.Add(collection);
                }
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var collection = await Quartz.CollectionById(iId, limit, offset, token: token);
                    collections.Add(collection);
                }
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var collection = await Opal.CollectionById(iId, limit, offset, token: token);
                    collections.Add(collection);
                }
            }
            catch
            {

            }
            try
            {
                var collection = await Basilisk.CollectionById(id, limit, offset, token: token);
                collections.Add(collection);
            }
            catch
            {

            }
            try
            {
                var collection = await Glmr.CollectionById(id, limit, offset, token: token);
                collections.Add(collection);
            }
            catch
            {

            }
            try
            {
                var collection = await Movr.CollectionById(id, limit, offset, token: token);
                collections.Add(collection);
            }
            catch
            {

            }


            return collections;
        }

        /// <summary>
        /// returns collections where issuer (creator) is equal to provided address
        /// <example>
        /// <code>
        /// await Uniquery.Universal.CollectionListByIssuer("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Collection>> CollectionListByIssuer(
            string issuerAddress,
            int limit = 10,
            int offset = 0,
            CancellationToken token = default(CancellationToken))
        {
            List<Collection> collections = new List<Collection>();

            collections.AddRange(await Rmrk.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await RmrkV2.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Unique.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Quartz.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Opal.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Basilisk.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Movr.CollectionListByIssuer(issuerAddress, limit, offset, token: token));
            collections.AddRange(await Glmr.CollectionListByIssuer(issuerAddress, limit, offset, token: token));

            return collections;
        }

        /// <summary>
        /// returns collections where name contains provided name
        /// <example>
        /// <code>
        /// await Uniquery.Universal.CollectionListByName("Shaban");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Collection>> CollectionListByName(
            string collectionName,
            int limit = 10,
            int offset = 0,
            CancellationToken token = default(CancellationToken))
        {
            List<Collection> collections = new List<Collection>();

            collections.AddRange(await Rmrk.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await RmrkV2.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Unique.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Quartz.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Opal.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Basilisk.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Glmr.CollectionListByName(collectionName, limit, offset, token: token));
            collections.AddRange(await Movr.CollectionListByName(collectionName, limit, offset, token: token));

            return collections;
        }

        /// <summary>
        /// returns collections where owner is equal to provided address
        /// <example>
        /// <code>
        /// await Uniquery.Universal.CollectionListByOwner("D5QWdFqn5FUaGFvgKGKtx8X4z1PVuXo8ZoGdhhCwc1vGJ3e");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Collection>> CollectionListByOwner(
            string ownerAddress,
            int limit = 10,
            int offset = 0,
            CancellationToken token = default(CancellationToken))
        {
            List<Collection> collections = new List<Collection>();

            collections.AddRange(await Rmrk.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await RmrkV2.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Unique.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Quartz.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Opal.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Basilisk.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Glmr.CollectionListByOwner(ownerAddress, limit, offset, token: token));
            collections.AddRange(await Movr.CollectionListByOwner(ownerAddress, limit, offset, token: token));

            return collections;
        }

        /// <summary>
        /// returns NFTs by id
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListById("18636665-C4F63647002B182C0E-WOLF4-WOLF4_2-0000000000000002")
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListById(
            string id,
            int limit = 1,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            try
            {
                var nft = await Rmrk.NftById(id, limit, offset, orderBy, forSale, eventsLimit, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await RmrkV2.NftById(id, limit, offset, orderBy, forSale, eventsLimit, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var nft = await Unique.NftById(iId, limit, offset, token: token);
                    nfts.Add(nft);
                }
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var nft = await Quartz.NftById(iId, limit, offset, token: token);
                    nfts.Add(nft);
                }
            }
            catch
            {

            }
            try
            {
                int iId;
                if (int.TryParse(id, out iId))
                {
                    var nft = await Opal.NftById(iId, limit, offset, token: token);
                    nfts.Add(nft);
                }
            }
            catch
            {

            }
            try
            {
                var nft = await Basilisk.NftById(id, limit, offset, orderBy, forSale, eventsLimit, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await Glmr.NftById(id, limit, offset, orderBy, eventsLimit, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await Movr.NftById(id, limit, offset, orderBy, forSale, eventsLimit, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await Acala.NftById(id, limit, offset, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await Astar.NftById(id, limit, offset, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }
            try
            {
                var nft = await Shiden.NftById(id, limit, offset, token: token);
                nfts.Add(nft);
            }
            catch
            {

            }

            return nfts;
        }

        /// <summary>
        /// returns NFTs where collection id is equal to provided id
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListByCollectionId(
            string collectionId,
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftListByCollectionId(collectionId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftListByCollectionId(collectionId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            int iCollectionId;
            if (int.TryParse(collectionId, out iCollectionId))
            {
                nfts.AddRange(await Unique.NftListByCollectionId(iCollectionId, limit, offset, token: token));
                nfts.AddRange(await Quartz.NftListByCollectionId(iCollectionId, limit, offset, token: token));
                nfts.AddRange(await Opal.NftListByCollectionId(iCollectionId, limit, offset, token: token));
            }
            nfts.AddRange(await Basilisk.NftListByCollectionId(collectionId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftListByCollectionId(collectionId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftListByCollectionId(collectionId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Acala.NftListByCollectionId(collectionId, limit, offset, token: token));
            nfts.AddRange(await Astar.NftListByCollectionId(collectionId, limit, offset, token: token));
            nfts.AddRange(await Shiden.NftListByCollectionId(collectionId, limit, offset, token: token));

            return nfts;
        }

        /// <summary>
        /// returns NFTs by name
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListByName("shape");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListByName(
            string name,
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftListByName(name, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftListByName(name, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Unique.NftListByName(name, limit, offset, token: token));
            nfts.AddRange(await Quartz.NftListByName(name, limit, offset, token: token));
            nfts.AddRange(await Opal.NftListByName(name, limit, offset, token: token));
            nfts.AddRange(await Basilisk.NftListByName(name, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftListByName(name, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftListByName(name, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Acala.NftListByName(name, limit, offset, token: token));
            nfts.AddRange(await Astar.NftListByName(name, limit, offset, token: token));
            nfts.AddRange(await Shiden.NftListByName(name, limit, offset, token: token));

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Nft metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListByMetadataId(
            string metadataId,
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftListByMetadataId(metadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftListByMetadataId(metadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            // Unique, Quartz, Opal are not supported.
            nfts.AddRange(await Basilisk.NftListByMetadataId(metadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftListByMetadataId(metadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftListByMetadataId(metadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Acala.NftListByMetadataId(metadataId, limit, offset, token: token));
            nfts.AddRange(await Astar.NftListByMetadataId(metadataId, limit, offset, token: token));
            nfts.AddRange(await Shiden.NftListByMetadataId(metadataId, limit, offset, token: token));

            return nfts;
        }

        /// <summary>
        /// returns NFTs where metadata match Collection metadata id
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListByCollectionMetadataId(
            string collectionMetadataId,
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftListByCollectionMetadataId(collectionMetadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftListByCollectionMetadataId(collectionMetadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            // Unique, Quartz, Opal are not supported.
            nfts.AddRange(await Basilisk.NftListByCollectionMetadataId(collectionMetadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftListByCollectionMetadataId(collectionMetadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftListByCollectionMetadataId(collectionMetadataId, limit, offset, orderBy, forSale, eventsLimit, token: token));
            // Acala, Astar, Shiden are not supported.

            return nfts;
        }

        /// <summary>
        /// returns NFTs owned by the address
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftListByOwner(
            string address,
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Unique.NftListByOwner(address, limit, offset, token: token));
            nfts.AddRange(await Quartz.NftListByOwner(address, limit, offset, token: token));
            nfts.AddRange(await Opal.NftListByOwner(address, limit, offset, token: token));
            nfts.AddRange(await Basilisk.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Acala.NftListByOwner(address, limit, offset, token: token));
            nfts.AddRange(await Astar.NftListByOwner(address, limit, offset, token: token));
            nfts.AddRange(await Shiden.NftListByOwner(address, limit, offset, token: token));

            return nfts;
        }

        /// <summary>
        /// returns NFTs
        /// <example>
        /// <code>
        /// await Uniquery.Universal.NftList(forSale: true);
        /// </code>
        /// </example>
        /// </summary>
        public static async Task<List<Nft>> NftList(
            int limit = 10,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken))
        {
            List<Nft> nfts = new List<Nft>();

            nfts.AddRange(await Rmrk.NftList(limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await RmrkV2.NftList(limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Unique.NftList(limit, offset, token: token));
            nfts.AddRange(await Quartz.NftList(limit, offset, token: token));
            nfts.AddRange(await Opal.NftList(limit, offset, token: token));
            nfts.AddRange(await Basilisk.NftList(limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Glmr.NftList(limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Movr.NftList(limit, offset, orderBy, forSale, eventsLimit, token: token));
            nfts.AddRange(await Acala.NftList(limit, offset, token: token));
            nfts.AddRange(await Astar.NftList(limit, offset, token: token));
            nfts.AddRange(await Shiden.NftList(limit, offset, token: token));

            return nfts;
        }
    }
}

