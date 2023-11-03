using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class BasiliskEventService
	{
        private class ResponseType
        {
            [JsonPropertyName("events")]
            public List<BasiliskEvent> Events { get; set; }
        }

        public static async Task<List<BasiliskEvent>> GetEventEntitiesAsync(
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
                    query MyQuery ($limit: Int!, $offset: Int!, $where: EventWhereInput, $orderBy: [EventOrderByInput!]!) {
                      events(limit: $limit, offset: $offset, where: $where, orderBy: $orderBy) {
                        caller
                        blockNumber
                        currentOwner
                        id
                        interaction
                        meta
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

            var graphQLResponse = await Basilisk.client.SendQueryAsync<ResponseType>(request, token);

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

