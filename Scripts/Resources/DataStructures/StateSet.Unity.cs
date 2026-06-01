#if UNITY_EDITOR
using UnityEngine;

namespace DMBTools
{
    /// <summary>
    /// Unity-specific partial extension for StateSet with additional Unity features
    /// </summary>
    public partial class StateSet
    {
        /// <summary>
        /// Creates a StateSet from GameObjects with specific tags
        /// </summary>
        /// <param name="tags">GameObject tags to include as states</param>
        /// <returns>StateSet with tag-based states</returns>
        public static StateSet FromGameObjectTags(params string[] tags)
        {
            var stateSet = new StateSet();
            foreach (string tag in tags)
            {
                var objects = GameObject.FindGameObjectsWithTag(tag);
                stateSet.Add(new State(tag.ToLower(), objects.Length > 0));
            }
            return stateSet;
        }
        
        /// <summary>
        /// Validates StateSet in Unity editor for debugging
        /// </summary>
        public void LogStates()
        {
            foreach (var state in list)
            {
                Debug.Log($"State: {state.key} = {state.flag}");
            }
        }
    }
}
#endif