using UnityEngine.InputSystem;

namespace DMBTools
{
    [System.Serializable]
    public struct State
    {
        public string key;
        public bool stateFlag;

        public State(string key, bool value)
        {
            this.key = key.ToLower();
            this.stateFlag = value;
        }
        public State(string key): this(key, false) { }

        /* Comparing states compares their keys rather than their stateFlags for uniqueness */
        readonly public bool Equals(State target) => target.key.Equals(key);

        readonly public bool DeeplyEquals(State target) =>
            target.key.Equals(key) &&
            target.stateFlag.Equals(stateFlag);
    }
}