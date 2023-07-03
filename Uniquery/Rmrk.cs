using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net;

namespace Uniquery
{
    public class Rmrk
    {
        private readonly static GraphQLHttpClient _client = new GraphQLHttpClient(
            "https://squid.subsquid.io/rubick/graphql", new NewtonsoftJsonSerializer()
            );

        public static void Hello()
        {
            Console.WriteLine("Hello there!");
        }
    };
}