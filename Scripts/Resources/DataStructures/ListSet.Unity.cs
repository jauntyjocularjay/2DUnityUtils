#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace DMBTools
{
    /// <summary>
    /// Unity-specific partial extension for ListSet with Unity helper methods
    /// </summary>
    public partial class ListSet<T>
    {
        /// <summary>
        /// Unity serialized version of the list for inspector visibility
        /// </summary>
        [SerializeField] private List<T> serializedList = new List<T>();
        
        /// <summary>
        /// Call this in Awake() or Start() to sync Unity serialization with core list
        /// </summary>
        public void InitializeForUnity()
        {
            if (serializedList != null && serializedList.Count > 0)
            {
                list = serializedList;
            }
            else
            {
                serializedList = list ?? new List<T>();
            }
        }
        
        /// <summary>
        /// Syncs the core list with Unity's serialized list (call when modifying at runtime)
        /// </summary>
        public void SyncToUnity()
        {
            serializedList = list;
        }
        
        /// <summary>
        /// Logs the count and contents of the ListSet for Unity debugging
        /// </summary>
        public void LogContents(string label = "ListSet")
        {
            Debug.Log($"{label} Count: {list?.Count ?? 0}");
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Debug.Log($"{label}[{i}]: {list[i]}");
                }
            }
        }
        
        /// <summary>
        /// Validates that the ListSet is properly initialized for Unity
        /// </summary>
        public bool IsValidForUnity()
        {
            return list != null;
        }
    }
}
#endif