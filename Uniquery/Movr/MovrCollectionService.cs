using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public static class MovrCollectionService
    {
        private class ResponseType
        {
            [JsonPropertyName("collectionEntities")]
            public List<MovrCollection> CollectionEntities { get; set; }
        }

        public static async Task<List<MovrCollection>> GetCollectionEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC"
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery($where: CollectionEntityWhereInput, $limit: Int, $offset: Int, $orderBy: [CollectionEntityOrderByInput!]) {
                      collectionEntities(limit: $limit, offset: $offset, orderBy: $orderBy, where: $where) {
                        blockNumber
                        burned
                        createdAt
                        currentOwner
                        id
                        max
                        issuer
                        metadata
                        name
                        symbol
                        type
                        updatedAt
                        meta {
                          animationUrl
                          id
                          image
                          name
                          type
                          description
                          attributes {
                            display
                            trait
                            value
                          }
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

            var graphQLResponse = await Movr.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var collection in graphQLResponse.Data.CollectionEntities)
            {
                collection.NetworkFormat = "movr";
            }

            return graphQLResponse.Data.CollectionEntities;
        }
    }
}
