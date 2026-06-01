using System;
using System.Collections.Generic;

namespace DMBTools
{
    /// <summary>
    /// A hybrid collection that combines List functionality with Set uniqueness constraints.
    /// Maintains insertion order like a List while preventing duplicate elements like a Set.
    /// 
    /// Key characteristics:
    /// - Preserves insertion order (unlike HashSet)
    /// - Prevents duplicate elements (unlike List)  
    /// - Provides indexed access (like List)
    /// - Uses Contains() for uniqueness checks (O(n) operation)
    /// 
    /// Use when you need:
    /// - Ordered collection without duplicates
    /// - Both indexed access and set semantics
    /// - Predictable iteration order
    /// 
    /// Performance considerations:
    /// - Add operations: O(n) due to Contains() check
    /// - Index access: O(1)
    /// - Contains check: O(n) 
    /// 
    /// For large collections requiring frequent uniqueness checks, consider HashSet + List combo.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Must support equality comparison.</typeparam>
    [System.Serializable]  
    public partial class ListSet<T>
    {
        /// <summary>
        /// Internal List that stores the elements while maintaining order.
        /// Protected to allow derived classes and Unity serialization access.
        /// </summary>
        protected List<T> list;
        
        /// <summary>
        /// Gets the number of elements in the ListSet.
        /// </summary>
        public int Count => list.Count;
        
        /// <summary>
        /// Initializes a new empty ListSet.
        /// </summary>
        public ListSet() => list = new List<T>();
        
        /// <summary>
        /// Initializes a new ListSet with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity of the underlying list</param>
        public ListSet(int capacity) => list = new List<T>(capacity);
        
        /// <summary>
        /// Initializes a new ListSet with elements from the specified collection.
        /// Duplicates in the source collection will be included without uniqueness filtering.
        /// </summary>
        /// <param name="collection">Collection to copy elements from</param>
        public ListSet(IEnumerable<T> collection) => list.AddRange(collection);

        /*** Iteration and Enumeration ***/
        
        /// <summary>
        /// Returns an enumerator that iterates through the ListSet in insertion order.
        /// </summary>
        /// <returns>An enumerator for the ListSet</returns>
        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        
        /// <summary>
        /// Performs the specified action on each element in the ListSet.
        /// Elements are processed in insertion order.
        /// </summary>
        /// <param name="action">The action to perform on each element</param>
        public void ForEach(Action<T> action) => list.ForEach(action);

        /*** Indexed Access ***/
        
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// 
        /// When setting: Only sets the value if it doesn't already exist elsewhere in the collection.
        /// This maintains uniqueness but may result in the assignment being silently ignored.
        /// 
        /// Warning: The setter's uniqueness check may cause unexpected behavior. 
        /// Consider using Remove() followed by Insert() for explicit replacement.
        /// </summary>
        /// <param name="i">The zero-based index of the element to get or set</param>
        /// <returns>The element at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Index is outside the bounds of the collection</exception>
        public T this[int i]
        {
            get => list[i];
            set
            {
                // Only assign if the new value doesn't exist elsewhere in the collection
                // This prevents duplicates but may silently fail to update
                if (!list.Contains(value)) list[i] = value;
            }
        }

        /*** Element Addition ***/
        
        /// <summary>
        /// Adds an element to the ListSet if it doesn't already exist.
        /// This is the core method that enforces Set uniqueness semantics.
        /// </summary>
        /// <param name="element">The element to add to the ListSet</param>
        /// <returns>true if the element was added; false if it already exists</returns>
        /// <remarks>
        /// Performance: O(n) due to Contains() check.
        /// For large collections, consider using HashSet for faster duplicate detection.
        /// </remarks>
        public bool Add(T element)
        {
            // Check for existing element using default equality comparer
            if (list.Contains(element))
                return false; // Element already exists, maintain uniqueness
            else
            {
                list.Add(element); // Add to end, maintaining insertion order
                return true;
            }
        }
        
        /// <summary>
        /// Attempts to add multiple elements from a collection.
        /// Duplicates are skipped and logged as warnings.
        /// </summary>
        /// <param name="collection">Collection of elements to add</param>
        /// <remarks>
        /// Warning: This method uses Console.WriteLine for duplicate warnings,
        /// which may not be appropriate for all environments (Unity, web apps, etc.).
        /// Consider using a logging framework or event-based notification instead.
        /// 
        /// Each element is checked individually, so this is an O(n²) operation in worst case.
        /// </remarks>
        public void Add(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                if (!Add(item)) // Leverage existing Add() method with its uniqueness logic
                {
                    // TODO: Consider replacing Console.WriteLine with configurable logging
                    Console.WriteLine($"WARNING: {item} is a duplicate, use Set() to update values");
                }
            }
        }
        
        /// <summary>
        /// Sets an element in the ListSet, adding if new or replacing if it already exists.
        /// This provides "upsert" functionality - update or insert.
        /// </summary>
        /// <param name="element">The element to set</param>
        /// <returns>true if the element was added (new); false if it was updated (replaced existing)</returns>
        /// <remarks>
        /// This method solves the limitation of Add() which fails on existing elements.
        /// Use this when you want to ensure an element exists with a specific value,
        /// regardless of whether it's currently in the collection.
        /// Performance: O(n) due to IndexOf() check.
        /// </remarks>
        public bool Set(T element)
        {
            int existingIndex = list.IndexOf(element);
            if (existingIndex >= 0)
            {
                // Element exists, replace it in place
                list[existingIndex] = element;
                return false; // Was an update
            }
            else
            {
                // Element doesn't exist, add it
                list.Add(element);
                return true; // Was an add
            }
        }
        
        /// <summary>
        /// Updates the element at the specified index, maintaining uniqueness constraints.
        /// If the new element would create a duplicate, the existing duplicate is removed first.
        /// </summary>
        /// <param name="index">The zero-based index of the element to update</param>
        /// <param name="element">The new element to place at the specified index</param>
        /// <exception cref="ArgumentOutOfRangeException">Index is outside the bounds of the collection</exception>
        /// <remarks>
        /// This method solves the limitation of the indexer setter which silently fails.
        /// Unlike the indexer, this method will always update the element at the specified index,
        /// removing duplicates elsewhere if necessary to maintain uniqueness.
        /// Performance: O(n) due to duplicate detection and potential element removal.
        /// </remarks>
        public void Update(int index, T element)
        {
            // Validate index first
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Check if element exists elsewhere
            int existingIndex = list.IndexOf(element);
            if (existingIndex >= 0 && existingIndex != index)
            {
                // Remove the duplicate element first
                list.RemoveAt(existingIndex);
                // Adjust index if the removed element was before our target
                if (existingIndex < index)
                    index--;
            }
            
            // Set the element at the specified index
            list[index] = element;
        }
        
        /// <summary>
        /// Inserts an element at the specified index if it doesn't already exist.
        /// If the element exists elsewhere, the insertion is silently ignored.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert the element</param>
        /// <param name="element">The element to insert</param>
        /// <remarks>
        /// Warning: Silent failure when element already exists may cause confusion.
        /// The index positions of existing elements may change due to insertion.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Index is outside the valid range</exception>
        public void Insert(int index, T element)
        {
            // Maintain uniqueness by checking existence first
            if (list.Contains(element)) return; // Silent failure - consider throwing exception instead
            else list.Insert(index, element);
        }
        
        /// <summary>
        /// Inserts multiple elements from a collection at the specified index.
        /// Elements that already exist are silently skipped.
        /// Each successive element is inserted at the same index, effectively reversing their order.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert elements</param>
        /// <param name="collection">Collection of elements to insert</param>
        /// <remarks>
        /// Warning: This method inserts each element at the same index position,
        /// which results in the collection being inserted in reverse order.
        /// This may not be the intended behavior.
        /// 
        /// Consider incrementing the index for each insertion to maintain original order:
        /// for(int i = 0; i &lt; collection.Count(); i++) Insert(index + i, collection[i]);
        /// </remarks>
        public void Insert(int index, IEnumerable<T> collection)
        {
            foreach(T element in collection)
            {
                Insert(index, element); // Note: This inserts at same index repeatedly
            }
        }
        /*** Element Queries ***/
        
        /// <summary>
        /// Determines whether the ListSet contains a specific element.
        /// Uses the default equality comparer for type T.
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>true if the element is found; otherwise, false</returns>
        /// <remarks>Performance: O(n) linear search through the collection</remarks>
        public bool Contains(T element)
        {
            return list.Contains(element);
        }
        
        /// <summary>
        /// Searches for the specified element and returns its zero-based index.
        /// </summary>
        /// <param name="element">The element to locate</param>
        /// <returns>
        /// The zero-based index of the first occurrence of the element, if found; 
        /// otherwise, -1
        /// </returns>
        /// <remarks>Performance: O(n) linear search through the collection</remarks>
        public int IndexOf(T element) => list.IndexOf(element);

        /*** Element Removal ***/
        
        /// <summary>
        /// Removes the first occurrence of the specified element from the ListSet.
        /// </summary>
        /// <param name="element">The element to remove</param>
        /// <remarks>
        /// If the element exists multiple times (which shouldn't happen in a well-formed ListSet),
        /// only the first occurrence is removed.
        /// Elements after the removed element are shifted down by one position.
        /// Performance: O(n) due to search and potential shifting of elements.
        /// </remarks>
        public void Remove(T element) => list.Remove(element);
        
        /// <summary>
        /// Removes the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove</param>
        /// <remarks>
        /// Elements after the removed element are shifted down by one position.
        /// Performance: O(n) due to potential shifting of elements.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Index is outside the bounds of the collection</exception>
        public void RemoveAt(int index) => list.RemoveAt(index);

        /// <summary>
        /// Removes all elements from the ListSet.
        /// </summary>
        /// <remarks>
        /// After calling this method, Count will be 0.
        /// The capacity of the underlying list is not changed.
        /// </remarks>
        public void Clear() => list.Clear();

        /*** Collection Conversion ***/
        
        /// <summary>
        /// Copies the elements of the ListSet to a new array.
        /// </summary>
        /// <returns>
        /// An array containing copies of all elements in the ListSet, 
        /// in the same order they were inserted
        /// </returns>
        /// <remarks>
        /// This creates a snapshot of the current state.
        /// Changes to the returned array do not affect the ListSet.
        /// Performance: O(n) to copy all elements.
        /// </remarks>
        public T[] ToArray() => list.ToArray();

        /// <summary>
        /// Copies the elements of the ListSet to an existing array, 
        /// starting at the specified array index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional array that is the destination of the copied elements.
        /// The array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based index in the destination array at which copying begins
        /// </param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">arrayIndex is less than 0</exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the ListSet is greater than the available space 
        /// from arrayIndex to the end of the destination array
        /// </exception>
        /// <remarks>
        /// Elements are copied in insertion order.
        /// The destination array must be compatible with type T.
        /// Performance: O(n) to copy all elements.
        /// </remarks>
        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        /*
         * ===== ListSet<T> SUMMARY =====
         * 
         * CONCEPT: Hybrid data structure combining List and Set characteristics
         * - Maintains insertion order like List<T>
         * - Enforces uniqueness like HashSet<T>
         * - Provides indexed access like arrays
         * 
         * PERFORMANCE PROFILE:
         * - Add(element): O(n) - must check for duplicates
         * - Contains(element): O(n) - linear search
         * - Index access [i]: O(1) - direct array access
         * - Remove operations: O(n) - search plus shifting
         * - Insert operations: O(n) - uniqueness check plus shifting
         * 
         * DESIGN ISSUES TO BE AWARE OF:
         * 1. Indexer setter silently ignores assignments that would create duplicates elsewhere
         * 2. Insert(index, collection) inserts elements in reverse order due to same-index insertion
         * 3. Add(collection) uses Console.WriteLine which is not appropriate for all environments
         * 4. Constructor with IEnumerable doesn't enforce uniqueness during initialization
         * 
         * IDEAL USE CASES:
         * - Small to medium collections (< 100 elements) where order matters
         * - Configuration data that must be unique but needs indexed access
         * - Migration from List<T> where uniqueness constraints are added
         * - Scenarios requiring both set semantics and list interface compatibility
         * 
         * ALTERNATIVES TO CONSIDER:
         * - For large datasets: HashSet<T> + List<T> combination for O(1) uniqueness checks
         * - For frequent lookups: Dictionary<T, int> mapping values to indices
         * - For immutable scenarios: ImmutableList<T> with validation
         * - For pure performance: Custom implementation with internal HashSet for tracking
         */

    }
}