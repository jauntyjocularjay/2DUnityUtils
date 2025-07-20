namespace DMBTools
{
    [System.Serializable]
    public struct State
    {
        public string key;
        public bool stateFlag;

        public State(string key, bool value)
        {
            this.key = key;
            this.stateFlag = value;
        }
    }
}