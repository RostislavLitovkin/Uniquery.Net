using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    internal class RmrkV2CollectionService
    {
        private class ResponseType
        {
            [JsonPropertyName("collectionEntities")]
            public List<RmrkV2Collection> CollectionEntities { get; set; }
        }

        public static async Task<List<RmrkV2Collection>> GetCollectionEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC"
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int!, $offset: Int!, $where: CollectionEntityWhereInput, $orderBy: [CollectionEntityOrderByInput!]!) {
                      collectionEntities(limit: $limit, offset: $offset, where: $where, orderBy: $orderBy) {
                        blockNumber
                        createdAt
                        currentOwner
                        events {
                          blockNumber
                          interaction
                          caller
                          meta
                          timestamp
                        }
                        hash
                        id
                        image
                        issuer
                        max
                        media
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
                        metadata
                        name
                        nftCount
                        supply
                        symbol
                        updatedAt
                        version
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

            var graphQLResponse = await RmrkV2.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            return graphQLResponse.Data.CollectionEntities;
        }
    }
}
