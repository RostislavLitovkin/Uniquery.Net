# Uniquery.Net

Easy to use tool for querying indexed NFT data.

Without Uniquery you would have to write something like this:

```GraphQL
query itemListByCollectionIdList {
  nft: nftEntities(where: { collection: { id_eq: "7EA1DCF47E98A25067-CAVE" }}) {
    id
    metadata
    currentOwner
    issuer
  }
}
```
With Uniquery you can write this:

```C#
string id = "7EA1DCF47E98A25067-CAVE";
var collections = await Uniquery.Rmrk.ItemListByCollectionId(id);
```

One of the cozy improvements over the original Kodadot Uniquery is the inclusion of `Uniquery.Universal`,
which allows quering of the data from multiple endpoints at the same time.

# Inspiration

- https://github.com/kodadot/uniquery - This project is a c# implementation of this original javascript package.
