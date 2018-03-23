using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods_NS
{
    public static class ExtensionMethods 
    {
        /// <summary>
        /// Select elements using selector function
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> ExtensionSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source != null && selector != null)
            {
                foreach (TSource item in source)
                {
                    yield return selector(item);
                }
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

        /// <summary>
        /// Return elements, which satisfy the demand
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ExtensionWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source != null && predicate != null)
            {
                foreach (TSource item in source)
                {
                    if (predicate(item))
                        yield return item;
                }
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

        /// <summary>
        /// Group elements by keySelector
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TSource>> ExtensionGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null && keySelector != null)
            {
                List<TSource> temp = new List<TSource>();
                foreach (var item in source)
                {
                    temp.Add(item);
                }
                
                Lookup<TKey, TSource> tempRet = (Lookup<TKey, TSource>)temp.ToLookup(keySelector);

                return tempRet;
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

        /// <summary>
        /// Transmute collection to list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TSource> ExtensionToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source != null)
            {
                List<TSource> temp = new List<TSource>();
                foreach (var item in source)
                    temp.Add(item);
                return temp;
            }
            else
                throw new Exception("Argument is null!");
            
        }

        /// <summary>
        /// Sort elements in ascending order by keySelector
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> ExtensionOrderByAsc<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null && keySelector != null)
            {
                //var temp = source.ExtensionSelect(keySelector);
                var temp = source.ExtensionToList();
                return temp.OrderBy(keySelector);
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

        /// <summary>
        /// Sort elements in descending order by keySelector
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TSource> ExtensionOrderByDesc<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null && keySelector != null)
            {
                var temp = source.ExtensionToList();
                return temp.OrderByDescending(keySelector);
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

        /// <summary>
        /// Transmute collection to dictionary
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TSource> ExtensionToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null && keySelector != null)
            {
                Dictionary<TKey, TSource> temp = new Dictionary<TKey, TSource>();
                foreach (var item in source)
                {
                    temp.Add(keySelector(item), item);
                }
                return temp;
            }
            else
                throw new Exception("Argument(s) is(are) null!");
        }

    }
}
