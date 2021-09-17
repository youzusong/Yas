using System.Linq;
using Yas.Core;

namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// 是否为空集合
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="source">集合源</param>
        /// <returns>是否为空集合</returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// 添加不存在的项
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="source">集合源</param>
        /// <param name="item">带添加的项</param>
        /// <returns>是否添加成功</returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            Check.NotNull(source, nameof(source));

            if (source.Contains(item))
                return false;

            source.Add(item);
            return true;
        }

        /// <summary>
        /// 添加不存在的项
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="source">集合源</param>
        /// <param name="items">待添加的集合</param>
        /// <returns>添加的集合</returns>
        public static IEnumerable<T> AddIfNotContains<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            Check.NotNull(source, nameof(source));

            var addedItems = new List<T>();

            foreach (var item in items)
            {
                if (source.Contains(item))
                    continue;

                source.Add(item);
                addedItems.Add(item);
            }

            return addedItems;
        }

        /// <summary>
        /// 添加不存在的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="itemFactory"></param>
        /// <returns>是否添加成功</returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, Func<T, bool> predicate, Func<T> itemFactory)
        {
            Check.NotNull(source, nameof(source));
            Check.NotNull(predicate, nameof(predicate));
            Check.NotNull(itemFactory, nameof(itemFactory));

            if (source.Any(predicate))
                return false;

            source.Add(itemFactory());
            return true;
        }

        /// <summary>
        /// 移除符合条件的项
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="source">集合源</param>
        /// <param name="predicate">条件</param>
        /// <returns>被移除的集合</returns>
        public static IList<T> RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
        {
            var items = source.Where(predicate).ToList();

            foreach (var item in items)
                source.Remove(item);

            return items;
        }

        /// <summary>
        /// 移除集合
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="source">集合源</param>
        /// <param name="items">待移除的集合</param>
        public static void RemoveAll<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Remove(item);
            }
        }
    }
}
