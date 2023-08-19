Everything in this repo has been coded from scratch during the Polkadot Global Series hackathon (3 – 23 July 2023).

This project is production ready.

# Uniquery.Net

Easy to use tool for querying indexed NFT data.

This is a c# implementation of [Uniquery](https://github.com/kodadot/uniquery) with many improvements on top.

### Improvements

- Overall structure has been improved:
    - confusing method `getClient("name")` has been replaced with static functions.
    - All types have been converted to native c# classes
- `Uniquery.Universal` - very cozy way to query data from multiple endpoints at the same time.
- Inclusion of new Networks/NftStandards, that are missing in the original uniquery: **Acala, Astar, Shiden, Unique, Quartz, Opal**
- More flexible parameters

# Installation

Nuget package: https://www.nuget.org/packages/Uniquery/
```
dotnet add package Uniquery
```

# Supported Networks/NftStandards

- [x] Rmrk
- [x] RmrkV2
- [x] Basilisk
- [x] Glmr
- [x] Movr
- [x] Unique
- [x] Quartz
- [x] Opal
- [x] Acala (OnFinality BETA)
- [x] Astar (OnFinality BETA)
- [x] Shiden (OnFinality BETA)

# Motivation

Originally, I just wanted query NFT data to display them in [PlutoWallet](https://github.com/RostislavLitovkin/PlutoWallet). Afterwards, I received request from [Kodadot](https://github.com/kodadot) to make a full c# implementation, hence, here it is.

This tool will be useful to many people and will significantly simplify the querying of NFT data.

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
var nfts = await Uniquery.Rmrk.NftListByCollectionId(id);
```

# Use of Uniquery.Universal

One of the major improvements over the original [Kodadot/Uniquery](https://github.com/kodadot/uniquery) js package is the inclusion of
`Uniquery.Universal`

Without `Uniquery.Universal` you would have to write something like this:

```C#
string address = "5HGuhwGJZC5zvWQm1kGpobJxwAv6bUtKyLGjKL7m2YaJtmDQ";
List<Nft> nfts = new List<Nft>();
nfts.AddRange(await Rmrk.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit));
nfts.AddRange(await RmrkV2.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit));
nfts.AddRange(await Unique.NftListByOwner(address, limit, offset));
nfts.AddRange(await Quartz.NftListByOwner(address, limit, offset));
nfts.AddRange(await Opal.NftListByOwner(address, limit, offset));
nfts.AddRange(await Basilisk.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit));
nfts.AddRange(await Glmr.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit));
nfts.AddRange(await Movr.NftListByOwner(address, limit, offset, orderBy, forSale, eventsLimit));
nfts.AddRange(await Acala.NftListByOwner(address, limit, offset));
nfts.AddRange(await Astar.NftListByOwner(address, limit, offset));
nfts.AddRange(await Shiden.NftListByOwner(address, limit, offset));
```
With `Uniquery.Universal` you can write this:
```C#
string address = "5HGuhwGJZC5zvWQm1kGpobJxwAv6bUtKyLGjKL7m2YaJtmDQ";
List<Nft> nfts = Uniquery.Universal.NftListByOwner(address);
```

# Documentation

### Methods
- CollectionById - Returns collection by id.
- CollectionListByIssuer - returns collections where issuer (creator) is equal to provided address
- CollectionListByName - returns collections where name contains provided name
- CollectionListByOwner - returns collections where owner is equal to provided address
- NftById - returns NFT by id
- NftListByCollectionId - returns NFTs where collection id is equal to provided id
- NftListByName - returns NFTs by name
- NftListByMetadataId - returns NFTs where metadata match Nft metadata id
- NftListByCollectionMetadataId - returns NFTs where metadata match Collection metadata id
- NftListByOwner - returns NFTs owned by the address
- NftList - returns NFTs
- EventList - returns all events
- EventListByAddress - returns events by address
- EventListByCollectionId - returns events by collection id
- EventListByInteraction - returns events by interaction
- EventListByNftId - returns events by nft id

### Parameters
- **<custom_parameter>** = custom filter parameter
- **limit** = number of returned items, **Default = 25**
- **offset** = offset of index of the returned items, **Default = 0**
- **orderBy** = ordering of the returned items, **Default = <time_desc>**

In-code documentation with wispering and examples is also included:
<img width="1003" alt="Screenshot 2023-07-07 at 11 49 19" src="https://github.com/RostislavLitovkin/Uniquery.Net/assets/77352013/d543d139-d508-4e90-a497-34b3e0b18785">

# Techstack used
- C#, graphql
- Subsquid api
- Unique network api
- OnFinality Unified NFT api (BETA)

# Inspiration

- https://github.com/kodadot/uniquery - This project is a c# implementation of this original javascript package.
