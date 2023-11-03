using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
    internal class RmrkV2NftService
    {
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<RmrkV2Nft> NftEntities { get; set; }
        }

        private class RmrkV2NftGraphQLVariables : GraphQLVariables
        {
            public int eventsLimit { get; set; }
            public int emotesLimit { get; set; }
        }

        public static async Task<List<RmrkV2Nft>> GetNftEntitiesAsync(
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
                        collection {
                          blockNumber
                          createdAt
                          currentOwner
                          hash
                          id
                          image
                          issuer
                          max
                          media
                          metadata
                          nftCount
                          name
                          supply
                          symbol
                          updatedAt
                          version
                        }
                        hash
                        id
                        image
                        instance
                        issuer
                        media
                        metadata
                        name
                        pending
                        price
                        recipient
                        royalty
                        sn
                        transferable
                        updatedAt
                        version
                        events(limit: $eventsLimit, orderBy: timestamp_DESC) {
                          blockNumber
                          caller
                          id
                          currentOwner
                          interaction
                          timestamp
                          version
                          meta
                        }
                        meta {
                          animationUrl
                          description
                          image
                          name
                          id
                          type
                          attributes {
                            display
                            trait
                            value
                          }
                        }
                        emotes(limit: $emotesLimit) {
                          caller
                          id
                          value
                          version
                        }
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new RmrkV2NftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                    emotesLimit = emotesLimit,
                },
            };

            var graphQLResponse = await RmrkV2.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var nft in graphQLResponse.Data.NftEntities)
            {
                nft.NetworkFormat = "rmrk2";
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}