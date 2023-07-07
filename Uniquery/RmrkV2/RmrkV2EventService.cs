using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class RmrkV2EventService
	{
        private class ResponseType
        {
            [JsonPropertyName("events")]
            public List<RmrkV2Event> Events { get; set; }
        }

        public static async Task<List<RmrkV2Event>> GetEventEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "timestamp_DESC"
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int!, $offset: Int!, $where: EventWhereInput, $orderBy: [EventOrderByInput!]!) {
                      events(limit: $limit, offset: $offset, where: $where, orderBy: $orderBy) {
                        id
                        blockNumber
                        caller
                        currentOwner
                        interaction
                        timestamp
                        meta
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

            return graphQLResponse.Data.Events;
        }
    }
}

