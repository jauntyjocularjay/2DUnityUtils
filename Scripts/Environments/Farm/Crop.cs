using System;
using System.Collections.Generic;
using UnityEngine;



namespace DMBTools
{
    public abstract class Crop : PhysicalProp
    {
        public List<Sprite> sprites;
        public List<int> phase = new List<int>{4};

        void FixedUpdate()
        {}
    }
}