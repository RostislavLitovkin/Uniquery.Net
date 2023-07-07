// This is a sample of how to use Uniquery

async Task RmrkTest()
{
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
    foreach (var e in events)
    {
        Console.WriteLine(e);
    }

    events = await Uniquery.Rmrk.EventListByCollectionId("C4F63647002B182C0E-NEON");
    foreach (var e in events)
    {
        Console.WriteLine(e);
    }

    events = await Uniquery.Rmrk.EventListByNftId("18641451-C4F63647002B182C0E-WOLF-WOLF_2-0000000000000002");
    foreach (var e in events)
    {
        Console.WriteLine(e);
    }
}

async Task UniqueTest()
{
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
}
async Task BasiliskTest()
{
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
}

async Task UniversalTest()
{
    var collections = await Uniquery.Universal.CollectionListById("10");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }
    collections = await Uniquery.Universal.CollectionListByOwner("5EJTrNheSa3iVUtuAPXg823zkHgwUAM5UQ5rhNgwpaLxrdpu");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }

    collections = await Uniquery.Universal.CollectionListByName("Opal");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }

    var nfts = await Uniquery.Universal.NftListByName("Ancient Opals");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.Universal.NftListByOwner("5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }


    nfts = await Uniquery.Universal.NftList();

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }
}

async Task RmrkV2Test() {
    var collections = await Uniquery.RmrkV2.CollectionListByIssuer("HCh9nv6WcmUAxhYEbqtBdfhyj7QNyqNzHJZhm5Y9v365Xbi");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }

    collections = await Uniquery.RmrkV2.CollectionListByName("kus");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }

    collections = await Uniquery.RmrkV2.CollectionListByOwner("HCh9nv6WcmUAxhYEbqtBdfhyj7QNyqNzHJZhm5Y9v365Xbi");

    foreach (var collection in collections)
    {
        Console.WriteLine(collection);
    }

    Console.WriteLine(await Uniquery.RmrkV2.CollectionById("ccae98d28cd76f9015-GRAFF"));

    Console.WriteLine(await Uniquery.RmrkV2.NftById("11685626-587a4c5c08ef2f0e51-RUG_PULL-TOPHAT_11-00000011"));

    var nfts = await Uniquery.RmrkV2.NftListByCollectionId("A4EC02A6BEF317A726-ACCTT");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.RmrkV2.NftListByName("shape", forSale: true);

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.RmrkV2.NftList(forSale: true);

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.RmrkV2.NftListByMetadataId("ipfs://ipfs/bafkreib26sbxwxfw4ydidc4a6zkm2w2obha7kz5ci3zo2rp46cqrjqpq4u");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.RmrkV2.NftListByCollectionMetadataId("ipfs://ipfs/bafkreiedd24yprvqul5ph6zf2vnbvtmhe75fdstfvwnco73v75yjvydnde");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }

    nfts = await Uniquery.RmrkV2.NftListByOwner("EyhuHahinimJJSTSuN2JNru3EFL3ry9dGKDfefbXUtJzjnb");

    foreach (var nft in nfts)
    {
        Console.WriteLine(nft);
    }
}

await RmrkV2Test();

Console.WriteLine("Done");
Console.ReadKey();
