using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    internal class MovrNftService
    {
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<MovrNft> NftEntities { get; set; }
        }

        private class MovrNftGraphQLVariables : GraphQLVariables
        {
            public int eventsLimit { get; set; }
            public int emotesLimit { get; set; }
        }

        public static async Task<List<MovrNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            bool forSale = false,
            int eventsLimit = 10,
            CancellationToken token = default(CancellationToken)
        )
        {

            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery($where: NFTEntityWhereInput!, $limit: Int, $NftLimit: Int, $orderBy: [NFTEntityOrderByInput!], $offset: Int) {
                      nftEntities(limit: $limit, offset: $offset, orderBy: $orderBy, where: " + 
                      (forSale ? @"{ AND: [ { price_not_eq: ""0"" }, $where] }" : "$where")
                        + @") {
                        blockNumber
                        burned
                        count
                        currentOwner
                        createdAt
                        hash
                        id
                        issuer
                        metadata
                        name
                        royalty
                        sn
                        price
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
                        events(orderBy: timestamp_DESC, limit: $NftLimit) {
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
                          id
                          currentOwner
                          max
                          issuer
                          metadata
                          name
                          symbol
                          type
                          updatedAt
                        }
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new MovrNftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                },
            };

            var graphQLResponse = await Movr.client.SendQueryAsync<ResponseType>(request, token);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            foreach (var nft in graphQLResponse.Data.NftEntities)
            {
                nft.NetworkFormat = "Movr";
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}
