using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public static class GlmrNftService
    {
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<GlmrNft> NftEntities { get; set; }
        }
        private class GlmrNftGraphQLVariables : GraphQLVariables
        {
            public int eventsLimit { get; set; }
        }

        public static async Task<List<GlmrNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            int eventsLimit = 10,
            bool forSale = false,
            CancellationToken token = default(CancellationToken)
        )
        {

            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery($limit: Int, $offset: Int, $orderBy: [NFTEntityOrderByInput!], $where: NFTEntityWhereInput!, $eventsLimit: Int) {
                        nftEntities(limit: $limit, offset: $offset, orderBy: $orderBy, where: " + 
                        (forSale ? @"{ AND: [ { price_not_eq: ""0"" }, $where] }" : "$where")
                        + @") {
                            blockNumber
                            burned
                            count
                            createdAt
                            currentOwner
                            hash
                            id
                            issuer
                            name
                            metadata
                            price
                            royalty
                            sn
                            updatedAt
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
                            events(limit: $eventsLimit) {
                              blockNumber
                              caller
                              currentOwner
                              id
                              interaction
                              meta
                              timestamp
                            }
                            collection {
                              blockNumber
                              burned
                              createdAt
                              currentOwner
                              id
                              issuer
                              max
                              metadata
                              name
                              symbol
                              type
                              updatedAt
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
                            }
                        }
                    }",
                OperationName = "MyQuery",
                Variables = new GlmrNftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                },
            };

            var graphQLResponse = await Glmr.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}
