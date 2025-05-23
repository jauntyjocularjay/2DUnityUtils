 using System.Collections.Generic;
 using UnityEngine;

namespace DMBTools
{
   public class FarmSimManager : Manager
   {
      public BoxPlayer player;
      public List<Crop> crops;
      public Sun sun;
      public Moon moon;

      public new void Start()
      {
         base.Start();


      }


   }
}