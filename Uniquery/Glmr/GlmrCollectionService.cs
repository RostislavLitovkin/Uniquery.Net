using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;

namespace Uniquery 
{
    public static class GlmrCollectionService
    {
        private class ResponseType
        {
            [JsonPropertyName("collectionEntities")]
            public List<GlmrCollection> CollectionEntities { get; set; }
        }

        public static async Task<List<GlmrCollection>> GetCollectionEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC"
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"query MyQuery($limit: Int, $offset: Int, $orderBy: [CollectionEntityOrderByInput!], $where: CollectionEntityWhereInput) {
  collectionEntities(limit: $limit, orderBy: $orderBy, offset: $offset, where: $where) {
    createdAt
    blockNumber
    id
    currentOwner
    burned
    issuer
    max
    metadata
    name
    symbol
    updatedAt
    type
    nfts(limit: 10) {
      blockNumber
      burned
      count
      createdAt
      currentOwner
      hash
      id
      issuer
      metadata
      name
      price
      royalty
      sn
      updatedAt
      meta {
        animationUrl
        description
        id
        image
        type
        name
        attributes {
          display
          trait
          value
        }
      }
      events(limit: 10) {
        blockNumber
        caller
        currentOwner
        interaction
        id
        meta
        timestamp
      }
    }
  }
}
",
                OperationName = "MyQuery",
                Variables = new GraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                },
            };

            var graphQLResponse = await Glmr.client.SendQueryAsync<ResponseType>(request);

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
