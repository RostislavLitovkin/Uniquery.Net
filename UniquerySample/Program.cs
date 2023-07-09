﻿// This is a sample of how to use Uniquery

/*
var collections = await Uniquery.Rmrk.CollectionListByIssuer("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

collections = await Uniquery.Rmrk.CollectionListByName("Shaban");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

collections = await Uniquery.Rmrk.CollectionListByOwner("D5QWdFqn5FUaGFvgKGKtx8X4z1PVuXo8ZoGdhhCwc1vGJ3e");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

Console.WriteLine(await Uniquery.Rmrk.CollectionById("7EA1DCF47E98A25067-CAVE"));


Console.WriteLine(await Uniquery.Rmrk.NftById("18636665-C4F63647002B182C0E-WOLF4-WOLF4_2-0000000000000002"));



var nfts = await Uniquery.Rmrk.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Rmrk.NftListByName("shape", forSale: true);

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}



nfts = await Uniquery.Rmrk.NftList(forSale: true);

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}


nfts = await Uniquery.Rmrk.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}



nfts = await Uniquery.Rmrk.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Rmrk.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}



var events = await Uniquery.Rmrk.EventList();

events = await Uniquery.Rmrk.EventListByAddress("GJZUpyxcKWEP4yGqBprRiif6AhLnBtfVEfxhu3hTVS1XDZz");
foreach (var e in events)
{
    Console.WriteLine(e);
}

events = await Uniquery.Rmrk.EventListByInteraction(Uniquery.RmrkInteraction.Buy);
foreach(var e in events)
{
    //Console.WriteLine(e);
}

events = await Uniquery.Rmrk.EventListByCollectionId("C4F63647002B182C0E-NEON");
foreach (var e in events)
{
    //Console.WriteLine(e);
}

events = await Uniquery.Rmrk.EventListByNftId("18641451-C4F63647002B182C0E-WOLF-WOLF_2-0000000000000002");
foreach (var e in events)
{
    //Console.WriteLine(e);
}
*/
/*
Console.WriteLine(await Uniquery.Quartz.CollectionById(10));

Console.WriteLine(await Uniquery.Unique.CollectionById(10));

Console.WriteLine(await Uniquery.Opal.CollectionById(1850));

var collections = await Uniquery.Opal.CollectionListByOwner("5EJTrNheSa3iVUtuAPXg823zkHgwUAM5UQ5rhNgwpaLxrdpu");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

collections = await Uniquery.Opal.CollectionListByName("Opal");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

var nfts = await Uniquery.Opal.NftListByName("Ancient Opals");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Opal.NftListByOwner("5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Opal.NftListByOwner("5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Opal.NftListByCollectionId(1850);

foreach (var nft in nfts)
{
    Console.WriteLine("Found by collection Id");
    Console.WriteLine(nft);
}

var events = await Uniquery.Quartz.EventList();

foreach (var e in events)
{
    Console.WriteLine("event list");
    Console.WriteLine(e);
}

events = await Uniquery.Unique.EventList();

foreach (var e in events)
{
    Console.WriteLine("event list");
    Console.WriteLine(e);
}

nfts = await Uniquery.Opal.NftList();

foreach (var nft in nfts)
{
    Console.WriteLine("Opal nft list");
    Console.WriteLine(nft);
}

nfts = await Uniquery.Quartz.NftList();

foreach (var nft in nfts)
{
    Console.WriteLine("Quartz nft list");
    Console.WriteLine(nft);
}

nfts = await Uniquery.Unique.NftList();

foreach (var nft in nfts)
{
    Console.WriteLine("Unique nft list");
    Console.WriteLine(nft);
}

Console.WriteLine("Done");
*/

/*
Console.WriteLine(await Uniquery.Basilisk.CollectionById("1"));

var collections = await Uniquery.Basilisk.CollectionListByIssuer("bXj4uMHTrBtVfmVMDpQ1AyUUNbnvLaRPcBDVTeLffL2h2U3KE");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

collections = await Uniquery.Basilisk.CollectionListByName("lin");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

collections = await Uniquery.Basilisk.CollectionListByOwner("bXj4uMHTrBtVfmVMDpQ1AyUUNbnvLaRPcBDVTeLffL2h2U3KE");

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}


Console.WriteLine(await Uniquery.Basilisk.NftById("4155379122-4"));

var nfts = await Uniquery.Basilisk.NftListByCollectionId("4155379122");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Basilisk.NftListByName("Snek", forSale: true);

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Basilisk.NftList(forSale: true);

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Basilisk.NftListByMetadataId("ipfs://ipfs/bafkreiaig3izwq2de7hiikzcfbfg4ax3xpofsxmkgb6p63xtan2k56x7vi");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Basilisk.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiaig3izwq2de7hiikzcfbfg4ax3xpofsxmkgb6p63xtan2k56x7vi");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}

nfts = await Uniquery.Basilisk.NftListByOwner("bXkmHMVWgX5k8JkKGqrAw1RCso6abY2U9Q5E12vvYZQxeNf7S");

foreach (var nft in nfts)
{
    Console.WriteLine(nft);
}


var events = await Uniquery.Basilisk.EventList();

events = await Uniquery.Basilisk.EventListByAddress("bXkmHMVWgX5k8JkKGqrAw1RCso6abY2U9Q5E12vvYZQxeNf7S");
foreach (var e in events)
{
    Console.WriteLine(e);
}

events = await Uniquery.Basilisk.EventListByInteraction(Uniquery.BasiliskInteraction.BUY);
foreach (var e in events)
{
    Console.WriteLine(e);
}

events = await Uniquery.Basilisk.EventListByCollectionId("4155379122");
foreach (var e in events)
{
    Console.WriteLine(e);
}

events = await Uniquery.Basilisk.EventListByNftId("4155379122-4");
foreach (var e in events)
{
    Console.WriteLine(e);
}

Console.ReadKey();
*/

Console.WriteLine("Uniquery.Glmr.CollectionById");
Console.WriteLine(await Uniquery.Glmr.CollectionById("0xb6e9e605aa159017173caa6181c522db455f6661"));


Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.CollectionListByIssuer");
var GlmrCollections = await Uniquery.Glmr.CollectionListByIssuer("0x24312a0b911fE2199fbea92efab55e2ECCeC637D", limit: 3);
foreach (var e in GlmrCollections)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.CollectionListByName");
GlmrCollections = await Uniquery.Glmr.CollectionListByName("Damned Pirates Society", limit: 3);
foreach (var e in GlmrCollections)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.CollectionListByOwner");
GlmrCollections = await Uniquery.Glmr.CollectionListByOwner("0xee6a0d688aA4b6a6BCfd4abEfFCB5ff731aFA9A0", limit: 3);
foreach (var e in GlmrCollections)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.EventList");
var GlmrEvents = await Uniquery.Glmr.EventList(limit: 3);
foreach (var e in GlmrEvents)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");

Console.WriteLine("Uniquery.Glmr.EventListByInteraction");
GlmrEvents = await Uniquery.Glmr.EventListByInteraction(Uniquery.GlmrInteraction.MINTNFT);
foreach (var e in GlmrEvents)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.EventListByAddress");
GlmrEvents = await Uniquery.Glmr.EventListByAddress("0xB047680e18b6dAD110883A08C9A73D655De9B8A8", limit: 3);
foreach (var e in GlmrEvents)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.EventListByCollectionId");
GlmrEvents = await Uniquery.Glmr.EventListByCollectionId("0xd3a9c48df4d9342dc1a0ee2c185ce50588729fa9", limit: 3);
foreach (var e in GlmrEvents)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.EventListByNftId");
GlmrEvents = await Uniquery.Glmr.EventListByNftId("0xd3a9c48df4d9342dc1a0ee2c185ce50588729fa9-1", limit: 3);
foreach (var e in GlmrEvents)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftById");
Console.WriteLine(await Uniquery.Glmr.NftById("0xb6e9e605aa159017173caa6181c522db455f6661-760"));

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftList");
var GlmrNfts = await Uniquery.Glmr.NftList(limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftListByCollectionId");
GlmrNfts = await Uniquery.Glmr.NftListByCollectionId("0x09a7f6e904bd6293ed382e905895efd0983f325f", limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftListByCollectionMetadataId");
GlmrNfts = await Uniquery.Glmr.NftListByCollectionMetadataId("ipfs://ipfs/QmYSThWjHh3swx2qXxGM6MMdv35hvCmaptNZFDXZisUHzi/1.json", limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftListByMetadataId");
GlmrNfts = await Uniquery.Glmr.NftListByMetadataId("ipfs://QmYSThWjHh3swx2qXxGM6MMdv35hvCmaptNZFDXZisUHzi/494.json", limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftListByName");
GlmrNfts = await Uniquery.Glmr.NftListByName("market", limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}

Console.WriteLine("==================================================================================================");
Console.WriteLine("Uniquery.Glmr.NftListByOwner");
GlmrNfts = await Uniquery.Glmr.NftListByOwner("0xd47991C1B656c391C59f7Ea90028267C24f60b49", limit: 3);
foreach (var e in GlmrNfts)
{
    Console.WriteLine(e);
    Console.WriteLine();
}




Console.WriteLine("FIN Success");
Console.ReadKey();
