// This is a sample of how to use Uniquery

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

Console.ReadKey();
