using System;
namespace Uniquery
{
	public class GraphQLVariables
	{
		public object where { get; set; }

		public int limit { get; set; }

		public int offset { get; set; }

		public string orderBy { get; set; }
	}
}

