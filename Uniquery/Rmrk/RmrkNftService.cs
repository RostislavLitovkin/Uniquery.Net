using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class RmrkNftService
	{
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<RmrkNft> NftEntities { get; set; }
        }

        private class RmrkNftGraphQLVariables: GraphQLVariables
        {
            public int eventsLimit { get; set; }
            public int emotesLimit { get; set; }
        }

        public static async Task<List<RmrkNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            int emotesLimit = 10,
            CancellationToken token = default(CancellationToken)
        )
        {

            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int!, $offset: Int!, $where: NFTEntityWhereInput!, $orderBy: [NFTEntityOrderByInput!]!, $eventsLimit: Int!, $emotesLimit: Int!) {
                      nftEntities(limit: $limit, offset: $offset, where: " +
                        (forSale ? @"{ OR: [ { price_not_eq: ""0"" }, $where] }" : "$where")
                      + @", orderBy: $orderBy) {
                        blockNumber
                        burned
                        createdAt
                        currentOwner
                        emoteCount
                        hash
                        id
                        issuer
                        instance
                        name
                        price
                        sn
                        transferable
                        updatedAt
                        meta {
                          animationUrl
                          description
                          id
                          image
                          name
                          type
                          attributes {
                            display
                            trait
                            value
                          }
                        }
                        metadata
                        events(limit: $eventsLimit, orderBy: timestamp_DESC) {
                          blockNumber
                          caller
                          currentOwner
                          id
                          interaction
                          meta
                          timestamp
                        }
                        emotes(limit: $emotesLimit) {
                          caller
                          id
                          value
                        }
                        collection {
                            blockNumber
                            createdAt
                            currentOwner
                            id
                            issuer
                            max
                            metadata
                            name
                            nftCount
                            symbol
                            supply
                            updatedAt
                            version
                        }
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new RmrkNftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                    emotesLimit = emotesLimit,
                },
            };
            
            var graphQLResponse = await Rmrk.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var nft in graphQLResponse.Data.NftEntities)
            {
                nft.NetworkFormat = "rmrk";
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}

