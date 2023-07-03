using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net;

namespace Uniquery
{
    public static class Rmrk
    {
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/rubick/graphql", new NewtonsoftJsonSerializer()
        );

        public static void Hello()
        {
            Console.WriteLine("Hello there!");
        }
    };
}