using System;
using GraphQL;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class OnFinalityNftService
	{
        private class ResponseType
        {
            [JsonPropertyName("nfts")]
            public NftData Nfts { get; set; }
        }

        private class NftData
        {
            [JsonPropertyName("edges")]
            public List<Edge> Edges { get; set; }
        }

        private class Edge
        {
            [JsonPropertyName("node")]
            public OnFinalityNft Node { get; set; }
        }


        public static async Task<List<OnFinalityNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0
        )
        {
            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
                    query MyQuery($where: NftFilter, $limit: Int, $offset: Int) {
                      nfts(first: $limit, offset: $offset, filter: $where) {
                        edges {
                          node {
                            amount
                            collectionId
                            currentOwner
                            id
                            metadataId
                            mintedBlock
                            minterAddress
                            mintedTimestamp
                            nodeId
                            tokenId
                            metadata {
                              description
                              id
                              imageUri
                              metadataStatus
                              metadataUri
                              name
                              nodeId
                              raw
                              symbol
                              tokenUri
                            }
                            collection {
                              contractAddress
                              contractType
                              createdBlock
                              createdTimestamp
                              creatorAddress
                              id
                              name
                              networkId
                              network {
                                id
                              }
                              nodeId
                              symbol
                              totalSupply
                            }
                          }
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

            var graphQLResponse = await OnFinalityClient.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                // OnFinality is unreliable at this point, so it is better to
                // just return an empty list than to throw an exception.
                // Maybe after a few months, this can be removed.
                return new List<OnFinalityNft>();

                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            List<OnFinalityNft> nfts = new List<OnFinalityNft>();
            foreach (var edge in graphQLResponse.Data.Nfts.Edges)
            {
                nfts.Add(edge.Node);
            }

            foreach (var nft in nfts)
            {
                switch (((OnFinalityCollection)nft.Collection).Network.Id)
                {
                    case "787":
                        nft.NetworkFormat = "acala";
                        break;
                    case "592":
                        nft.NetworkFormat = "astar";
                        break;
                    case "336":
                        nft.NetworkFormat = "shiden";
                        break;
                }
            }

            return nfts;
        }
    }
}

