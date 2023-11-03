using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class BasiliskNftService
	{
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<BasiliskNft> NftEntities { get; set; }
        }

        private class BasiliskNftGraphQLVariables : GraphQLVariables
        {
            public int eventsLimit { get; set; }
            public int offersLimit { get; set; }
        }

        public static async Task<List<BasiliskNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int offersLimit = 10,
            CancellationToken token = default(CancellationToken)
        )
        {

            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int!, $offset: Int!, $where: NFTEntityWhereInput!, $orderBy: [NFTEntityOrderByInput!]!, $eventsLimit: Int!, $offersLimit: Int!) {
                      nftEntities(limit: $limit, offset: $offset, where: " +
                        (forSale ? @"{ OR: [ { price_not_eq: ""0"" }, $where] }" : "$where")
                      + @", orderBy: $orderBy) {
                        blockNumber
                        burned
                        createdAt
                        currentOwner
                        id
                        hash
                        image
                        issuer
                        media
                        metadata
                        name
                        price
                        recipient
                        royalty
                        sn
                        updatedAt
                        offers(limit: $offersLimit) {
                          blockNumber
                          caller
                          createdAt
                          expiration
                          id
                          price
                          status
                          updatedAt
                        }
                        events(limit: $eventsLimit) {
                          blockNumber
                          caller
                          currentOwner
                          id
                          interaction
                          meta
                          timestamp
                        }
                        meta {
                          animationUrl
                          attributes {
                            display
                            trait
                            value
                          }
                          description
                          id
                          image
                          name
                          type
                        }
                        collection {
                            id
                            blockNumber
                            burned
                            createdAt
                            currentOwner
                            distribution
                            floor
                            highestSale
                            image
                            issuer
                            media
                            metadata
                            name
                            nftCount
                            supply
                            ownerCount
                            type
                            volume
                            updatedAt
                        }
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new BasiliskNftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                    offersLimit = offersLimit,
                },
            };

            var graphQLResponse = await Basilisk.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var nft in graphQLResponse.Data.NftEntities)
            {
                nft.NetworkFormat = "basilisk";
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}

