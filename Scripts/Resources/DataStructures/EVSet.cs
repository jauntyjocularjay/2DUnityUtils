using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace DMBTools
{
    [System.Serializable]
    public class EVSet<TEnum, TValue> : ISerializationCallbackReceiver where TEnum : System.Enum
    {
        [SerializeField] protected List<EVPair<TEnum, TValue>> pairs;
        protected Dictionary<TEnum, TValue> dict;

        public EVSet()
        {
            pairs = new List<EVPair<TEnum, TValue>>();
            dict = new Dictionary<TEnum, TValue>();
        }

        public void OnBeforeSerialize(){}
        public void OnAfterDeserialize()
        {
            // Commenting out this safety check;
            // uncomment the safety check if Unity fails to call the constructor
            // if (dict == null)
                dict = new Dictionary<TEnum, TValue>();
            // else
                // dict.Clear();

            foreach(EVPair<TEnum, TValue> pair in pairs)
            {
                dict[pair.Key] = pair.Value;
            }
        }

        public TValue this[TEnum key]
        {
            get => dict[key];
            set => dict[key] = value;
        }

    }

}



