using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Uniquery
{
	public class Basilisk
	{
        // GraphQL client that is always available.
        // This is an optimisation - reinitialization of the client is bad practice.
        public readonly static GraphQLHttpClient client = new GraphQLHttpClient(
            "https://squid.subsquid.io/snekk/graphql", new NewtonsoftJsonSerializer()
        );
    }
}

