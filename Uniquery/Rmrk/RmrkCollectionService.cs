using System;
using System.Text.Json.Serialization;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace Uniquery
{
    public static class RmrkCollectionService
    {
        private class ResponseType
        {
            [JsonPropertyName("collectionEntities")]
            public List<RmrkCollection> CollectionEntities { get; set; }
        }

        public static async Task<List<RmrkCollection>> GetCollectionEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            CancellationToken token = default(CancellationToken)
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int!, $offset: Int!, $where: CollectionEntityWhereInput, $orderBy: [CollectionEntityOrderByInput!]!) {
                      collectionEntities(limit: $limit, offset: $offset, where: $where, orderBy: $orderBy) {
                        version
                        updatedAt
                        symbol
                        supply
                        nftCount
                        name
                        metadata
                        max
                        issuer
                        currentOwner
                        createdAt
                        blockNumber
                        id
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
                        events {
                          blockNumber
                          caller
                          meta
                          interaction
                          timestamp
                        }
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

            var graphQLResponse = await Rmrk.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var collection in graphQLResponse.Data.CollectionEntities)
            {
                collection.NetworkFormat = "rmrk";
            }

            return graphQLResponse.Data.CollectionEntities;
        }
    }
}

