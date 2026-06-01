using UnityEngine;



namespace DMBTools
{
    public class ItemGenerator : MonoBehaviour
    {
        public GameObject[] itemPrefabToDrop;

        public void Drop()
        {
            if (itemPrefabToDrop.Length == 0)
            {
                throw new System.Exception("Item Generator does not have a prefab assigned to it.");
            }
            else if (itemPrefabToDrop.Length == 1)
            {
                GameObject.Instantiate(itemPrefabToDrop[0]);
            }
            else
            {
                int index = (int)(10.0f * UnityEngine.Random.Range(0, itemPrefabToDrop.Length - 1));
            }
        }
    }

}
