 using System.Collections.Generic;
 using UnityEngine;

namespace DMBTools
{
    public abstract class FarmSimManager : Manager
   {
      public BoxPlayer player;
      public List<Crop> crops;

       public new void Awake()
      {
         base.Awake();
      }
   }
}