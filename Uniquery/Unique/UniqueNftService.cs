using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class UniqueNftService
    {
        private class ResponseType
        {
            [JsonPropertyName("tokens")]
            public NftsWrapper Tokens { get; set; }

            [JsonPropertyName("count")]
            public int Count { get; set; }
        }

        private class NftsWrapper
        {
            [JsonPropertyName("data")]
            public List<UniqueNft> Data { get; set; }
        }

        public static async Task<List<UniqueNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int, $offset: Int, $where: TokenWhereParams) {
                      tokens(limit: $limit, offset: $offset, where: $where, order_by: { date_of_creation: desc }){
                        data {
                          attributes
                          bundle_created
                          burned
                          children_count
                          collection_cover
                          collection_description
                          collection_id
                          collection_name
                          collection_owner
                          collection_owner_normalized
                          date_of_creation
                          image
                          is_sold
                          nested
                          owner
                          owner_normalized
                          parent_id
                          properties
                          token_id
                          token_name
                          token_prefix
                          tokens_amount
                          tokens_parent
                          total_pieces
                          transfers_count
                        }
                        count
                      }
                    }",
                OperationName = "MyQuery",
                Variables = new GraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                },
            };

            var graphQLResponse = await Unique.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            return graphQLResponse.Data.Tokens.Data;
        }
    }
}

