using System.Collections.Generic;
using System.Linq;

namespace Mudz.Common
{
	public static class EqualityComparisonHelpers
	{
		public static T FirstMatching<T>(this IEnumerable<T> source, T comparison, IEqualityComparer<T> comparer)
		{
			return source.First(x => comparer.Equals(x, comparison));
		}
	}
}
