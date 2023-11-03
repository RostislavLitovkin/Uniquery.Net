using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    internal class GlmrEventService
    {
        private class ResponseType
        {
            [JsonPropertyName("events")]
            public List<GlmrEvent> Events { get; set; }
        }

        public static async Task<List<GlmrEvent>> GetEventEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC",
            CancellationToken token = default(CancellationToken)
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery($limit: Int, $offset: Int, $orderBy: [EventOrderByInput!], $where: EventWhereInput) {
                      events(offset: $offset, limit: $limit, orderBy: $orderBy, where: $where) {
                        blockNumber
                        caller
                        currentOwner
                        id
                        interaction
                        meta
                        nft {
                          blockNumber
                          burned
                          createdAt
                          currentOwner
                          issuer
                          hash
                          id
                          metadata
                          royalty
                          sn
                          updatedAt
                          price
                          name
                          meta {
                            animationUrl
                            id
                            name
                            type
                            image
                            attributes {
                              display
                              trait
                              value
                            }
                            description
                          }
                          collection {
                            blockNumber
                            burned
                            currentOwner
                            createdAt
                            id
                            max
                            issuer
                            metadata
                            name
                            symbol
                            type
                            updatedAt
                          }
                          count
                        }
                        timestamp
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new GraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
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
            return graphQLResponse.Data.Events;
        }
    }
}
