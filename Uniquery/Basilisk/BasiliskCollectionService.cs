using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class BasiliskCollectionService
	{
        private class ResponseType
        {
            [JsonPropertyName("collectionEntities")]
            public List<BasiliskCollection> CollectionEntities { get; set; }
        }

        public static async Task<List<BasiliskCollection>> GetCollectionEntitiesAsync(
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
                        blockNumber
                        burned
                        createdAt
                        currentOwner
                        distribution
                        floor
                        highestSale
                        id
                        image
                        issuer
                        media
                        metadata
                        name
                        nftCount
                        ownerCount
                        supply
                        type
                        updatedAt
                        volume
                        meta {
                            animationUrl
                            description
                            id
                            name
                            image
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
                            currentOwner
                            interaction
                            id
                            meta
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

            var graphQLResponse = await Basilisk.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var collection in graphQLResponse.Data.CollectionEntities)
            {
                collection.NetworkFormat = "basilisk";
            }

            return graphQLResponse.Data.CollectionEntities;
        }
    }
}

