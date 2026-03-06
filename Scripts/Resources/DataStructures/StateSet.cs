


using System.Collections.Generic;

namespace DMBTools
{
    public class StateSet : ListSet<State>
    {
        public Dictionary<string, bool> Dict()
        {
            Dictionary<string, bool> state = new Dictionary<string, bool>();

            foreach (State flag in list)
            {
                state.Add(flag.key, flag.stateFlag);
            }

            return state;
        }
    }
}
