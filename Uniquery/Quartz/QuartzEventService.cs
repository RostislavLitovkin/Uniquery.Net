using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class QuartzEventService
	{
        private class ResponseType
        {
            [JsonPropertyName("events")]
            public EventsWrapper Events { get; set; }
        }

        private class EventsWrapper
        {
            [JsonPropertyName("data")]
            public List<UniqueEvent> Data { get; set; }
        }

        public static async Task<List<UniqueEvent>> GetEventEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery ($limit: Int, $offset: Int, $where: EventWhereParams) {
                      events(limit: $limit, offset: $offset, where: $where, order_by: { block_number: desc }){
                        data {
                          block_index
                          block_number
                          collection_id
                          method
                          section
                          token_id
                        }
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

            var graphQLResponse = await Quartz.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }
            return graphQLResponse.Data.Events.Data;
        }
    }
}

