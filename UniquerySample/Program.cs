// This is a sample of how to use Uniquery

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

Console.ReadKey();

