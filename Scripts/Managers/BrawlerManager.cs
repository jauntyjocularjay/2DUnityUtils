using System.Collections.Generic;
using UnityEngine;

namespace DMBTools
{
    public abstract class BrawlerManager : Manager
    {
        public List<BoxPlayer> players;

        new void Start()
        {
            base.Start();
        }

    }
}