using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Test.Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string GetValues(this IEnumerable<int> list)
        {
            return string.Join("", list.Select(x => x.ToString()));
        }
    }
}
