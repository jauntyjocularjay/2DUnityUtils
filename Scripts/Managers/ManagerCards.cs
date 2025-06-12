using UnityEngine;



namespace DMBTools
{
    public abstract class CardManager: Manager
    {
        public Card[] exile = new Card[]{};
        new void Start()
        {
            base.Start();
        }
    }
}
