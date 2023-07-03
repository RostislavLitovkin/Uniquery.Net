// This is a sample of how to use Uniquery

var collections = await Uniquery.RmrkCollectionService.GetCollectionEntitiesAsync(null);

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

Console.WriteLine(await Uniquery.Rmrk.CollectionById("7EA1DCF47E98A25067-CAVE"));
Console.ReadKey();