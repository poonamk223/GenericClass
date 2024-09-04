using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericClass
{
    public class ValueTypeCollection<T> where T : struct, IComparable<T>
    {
        private List<T> _collection;
        public ValueTypeCollection()
        {
            _collection = new List<T>();
        }

        public void AddItem(T item)
        {
            _collection.Add(item);
        }
        public T GetItem(int index)
        {
            if (index < 0 || index >= _collection.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            return _collection[index];
        }
        public List<T> GetSortedDescending()
        {
            return _collection.OrderByDescending(item => item).ToList();
        }
    }

    public class Program
    {
        public static void Main()
        {
            var valueTypeCollection = new ValueTypeCollection<int>();

            valueTypeCollection.AddItem(10);
            valueTypeCollection.AddItem(5);
            valueTypeCollection.AddItem(20);

            Console.WriteLine($"Item at index 1: {valueTypeCollection.GetItem(1)}");
            var sortedCollection = valueTypeCollection.GetSortedDescending();
            Console.WriteLine("Sorted collection in descending order: ");
            foreach (var item in sortedCollection)
            {
                Console.WriteLine(item);
            }
        }
    }

}
