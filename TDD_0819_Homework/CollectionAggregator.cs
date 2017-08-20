using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TDD_0819_Homework
{
    public class CollectionAggregator
    {

        public static int[] Aggregate<T>(ICollection<T> source, int chunkSize, string property)
            where T : class
        {
            if (chunkSize < 0)
            {
                throw new ArgumentException("");
            }
            if (chunkSize == 0)
            {
                return new[] { 0 };
            }

            var dictionarilizedSource = source.Select(ObjectAsDictionary).ToList();

            if (!dictionarilizedSource.First().ContainsKey(property))
            {
                throw new ArgumentException("");
            }

            var chunkedList = Chunk(dictionarilizedSource, chunkSize);

            return chunkedList.Select(list => list.Aggregate(0, (sum, obj) => sum += (int) obj[property]))
                .ToArray();
        }

        private static Dictionary<string, object> ObjectAsDictionary(object source)
        {
            return source.GetType().GetProperties().ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }

        private static IEnumerable<List<T>> Chunk<T>(IEnumerable<T> collection, int chunkSize) where T : class
        {
            return collection.Select((obj, idx) => new { obj, idx })
                .GroupBy(part => part.idx / chunkSize)
                .Select(group => group.Select(part => part.obj).ToList())
                .ToList();
        }
    }
}
