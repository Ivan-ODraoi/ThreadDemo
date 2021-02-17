using System;
using System.Collections.Generic;
using Learnings.Exceptions; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnings.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<IEnumerable<TSource>, Exception> exceptionFactory )
        {
            var matchedItems = new List<TSource>();

            foreach(var item in source)
            {
                if (predicate(item))
                {
                    matchedItems.Add(item);
                }

            }
            if (matchedItems.Count > 50)
                return matchedItems;

           throw exceptionFactory(matchedItems);
            
        }

    }
}
