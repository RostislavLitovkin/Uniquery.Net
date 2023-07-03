// This is a sample of how to use Uniquery

var collections = await Uniquery.RmrkCollectionService.GetCollectionEntitiesAsync(null);

foreach (var collection in collections)
{
    Console.WriteLine(collection);
}

Console.ReadKey();