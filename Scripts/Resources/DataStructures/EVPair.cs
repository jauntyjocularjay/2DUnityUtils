using System;
using UnityEngine;


namespace DMBTools
{
    [System.Serializable]
    public struct EVPair<TEnum, TValue> : IEquatable<EVPair<TEnum, TValue>> where TEnum : System.Enum
    {
        public TEnum Key;
        public TValue Value;

        public EVPair(TEnum key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public bool Equals(EVPair<TEnum, TValue> target)
        {
            return this.Key.Equals(target.Key);
        }

        public override bool Equals(object obj)
            => obj is EVPair<TEnum, TValue> target && this.Equals(target);

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
        public override string ToString()
            => $"{this.Key}: {this.Value}";

        public static bool operator ==(EVPair<TEnum, TValue> left, EVPair<TEnum, TValue> right)
            => left.Equals(right);

        public static bool operator !=(EVPair<TEnum, TValue> left, EVPair<TEnum, TValue> right)
            => !left.Equals(right);
    }
}

