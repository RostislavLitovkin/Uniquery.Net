using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    internal class MovrEventService
    {
        private class ResponseType
        {
            [JsonPropertyName("events")]
            public List<MovrEvent> Events { get; set; }
        }

        public static async Task<List<MovrEvent>> GetEventEntitiesAsync(
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
                    query MyQuery($limit: Int, $offset: Int, $orderBy: [EventOrderByInput!], $where: EventWhereInput) {
                      events(limit: $limit, offset: $offset, orderBy: $orderBy, where: $where) {
                        blockNumber
                        caller
                        id
                        currentOwner
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

            var graphQLResponse = await Movr.client.SendQueryAsync<ResponseType>(request, token);

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
