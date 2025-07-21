using System;
using System.Collections.Generic;



namespace DMBTools
{
    [System.Serializable]
    public class ListSet<T>
    {
        List<T> list;
        int Count => list.Count;
        public ListSet() => list = new List<T>();
        public ListSet(int capacity) => list = new List<T>(capacity);
        public ListSet(IEnumerable<T> collection) => list.AddRange(collection);

        /*** Enumerator ***/
        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        /*** Indexer ***/
        public T this[int i]
        {
            get => list[i];
            set
            {
                if (!list.Contains(value)) list[i] = value;
            }
        }

        public bool Add(T element)
        {
            if (list.Contains(element))
                return false;
            else
            {
                list.Add(element);
                return true;
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                if (!Add(item))
                {
                    Console.WriteLine($"WARNING: {item} is a duplicate, use Set() to update values");
                }
            }
        }
        public void Insert(int index, T element)
        {
            if (list.Contains(element)) return;
            else list.Insert(index, element);
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }
        public int IndexOf(T element) => list.IndexOf(element);

        public void Remove(T element) => list.Remove(element);
        public void RemoveAt(int index) => list.RemoveAt(index);

        public void Clear() => list.Clear();

        public T[] ToArray() => list.ToArray();

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public void ForEach(Action<T> action) => list.ForEach(action);






    }
}