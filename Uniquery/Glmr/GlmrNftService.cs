using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public static class GlmrNftService
    {
        private class ResponseType
        {
            [JsonPropertyName("nftEntities")]
            public List<GlmrNft> NftEntities { get; set; }
        }
        private class GlmrNftGraphQLVariables : GraphQLVariables
        {
            public int eventsLimit { get; set; }
            public int nftsLimit { get; set; }
        }

        public static async Task<List<GlmrNft>> GetNftEntitiesAsync(
            object filter,
            int limit = 25,
            int offset = 0,
            string orderBy = "updatedAt_DESC",
            int eventsLimit = 10,
            int nftsLimit = 10
        )
        {

            GraphQLRequest request = new GraphQLRequest
            {
                Query = @"
query MyQuery($limit: Int, $offset: Int, $orderBy: [NFTEntityOrderByInput!], $where: NFTEntityWhereInput, $nftsLimit: Int, $eventsLimit: Int) {
  nftEntities(limit: $limit, offset: $offset, orderBy: $orderBy, where: $where) {
    blockNumber
    burned
    count
    createdAt
    currentOwner
    hash
    id
    issuer
    name
    metadata
    sn
    updatedAt
    price
    collection {
      blockNumber
      burned
      createdAt
      id
      max
      currentOwner
      issuer
      metadata
      name
      meta {
        animationUrl
        description
        name
        type
        image
        id
        attributes {
          display
          trait
          value
        }
      }
      symbol
      type
      updatedAt
      nfts(limit: $nftsLimit) {
        blockNumber
        burned
        count
        createdAt
        currentOwner
        id
        hash
        issuer
        metadata
        price
        royalty
        sn
        updatedAt
        name
        meta {
          animationUrl
          image
          type
          id
          name
          description
          attributes {
            display
            trait
            value
          }
        }
        collection {
          blockNumber
          burned
          createdAt
          currentOwner
          id
          issuer
          max
          metadata
          name
          symbol
          type
          updatedAt
        }
      }
    }
    events(limit: $eventsLimit) {
      blockNumber
      currentOwner
      id
      caller
      interaction
      meta
      timestamp
      nft {
        blockNumber
        burned
        createdAt
        currentOwner
        hash
        id
        issuer
        metadata
        sn
        name
        price
        royalty
        updatedAt
        meta {
          animationUrl
          description
          type
          name
          image
          id
          attributes {
            display
            trait
            value
          }
        }
        collection {
          blockNumber
          burned
          createdAt
          currentOwner
          id
          issuer
          max
          metadata
          name
          symbol
          type
          updatedAt
        }
        count
      }
    }
    meta {
      animationUrl
      attributes {
        display
        trait
        value
      }
      image
      name
      description
      id
      type
    }
    royalty
  }
}",
                OperationName = "MyQuery",
                Variables = new GlmrNftGraphQLVariables
                {
                    where = filter,
                    offset = offset,
                    limit = limit,
                    orderBy = orderBy,
                    eventsLimit = eventsLimit,
                    nftsLimit = nftsLimit,
                },
            };

            var graphQLResponse = await Glmr.client.SendQueryAsync<ResponseType>(request);

            if (graphQLResponse.Errors != null && graphQLResponse.Errors.Length > 0)
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    throw new Exception(error.Message);
                }
            }

            return graphQLResponse.Data.NftEntities;
        }
    }
}
