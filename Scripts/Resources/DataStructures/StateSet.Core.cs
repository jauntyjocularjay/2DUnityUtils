using System.Collections.Generic;
using System.Diagnostics;

namespace DMBTools
{
    [System.Serializable]
    public partial class StateSet : ListSet<State>
    {
        /// <summary>
        /// Gets or sets the flag value for a state with the specified key.
        /// If the key doesn't exist when getting, returns false.
        /// If the key doesn't exist when setting, creates a new state.
        /// </summary>
        /// <param name="key">The state key to lookup or create</param>
        /// <returns>The flag value of the state with the specified key, or false if not found</returns>
        /// <remarks>
        /// This indexer provides convenient dictionary-like access to state flags by key.
        /// Uses the inherited Set() method for upsert behavior when setting values.
        /// Keys are automatically normalized to lowercase for consistent lookup.
        /// 
        /// Examples:
        /// - bool isJumping = stateSet["jumping"];  // Returns flag value or false
        /// - stateSet["jumping"] = true;            // Sets flag, creates state if needed
        /// </remarks>
        public bool this[string key]
        {
            get 
            {
                string normalizedKey = key.ToLower();
                int index = list.FindIndex(s => s.key == normalizedKey);
                return index >= 0 ? list[index].flag : false;
            }
            set
            {
                this.Set(new State(key, value)); // Uses upsert behavior from ListSet
            }
        }

        public Dictionary<string, bool> Dict()
        {
            Dictionary<string, bool> state = new Dictionary<string, bool>();

            foreach (State flag in list)
            {
                state.Add(flag.key, flag.flag);
            }

            return state;
        }

        /// <summary>
        /// Attempts to update the StateSet from a dictionary of key-value pairs.
        /// Only adds states that don't already exist - existing states are not modified.
        /// </summary>
        /// <param name="reference">Dictionary containing state keys and boolean values</param>
        /// <remarks>
        /// Warning: This method uses Add() internally, so existing states will NOT be updated.
        /// States that already exist in the StateSet will be skipped.
        /// Use Set() method on individual states if you need update behavior.
        /// </remarks>
        public void UpdateFrom(Dictionary<string, bool> reference)
        {
            foreach(var element in reference)
            {
                State newState = new State(element.Key, element.Value);
                this.Add(newState);
            }
        }
    }
}
