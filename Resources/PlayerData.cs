using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName ="Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public int MaxHP = 3;
    public int HP;
    public float velocity = 7;
    public bool courtesyBar = false;
    public int jumps = 0;
    public float mass = 1.0f;
    public float gravityScale = 1.0f;
    public int layerID = 0;
    public int sortingOrder = 1;
    public Vector2 colliderOffset;
    public Vector2 colliderSize;
    public Vector3 movementVelocity;
    void Awake()
    {
        colliderOffset = new Vector2(0.0f,1.75f);
        colliderSize = new Vector2(1.0f, 3.5f);
        movementVelocity = new Vector3(5.0f, 3.0f, 0.0f);
    }
    public int GetHP()
    {
        return HP;
    }
    int IncrementHP(int i)
    {
        return HP + i;
    }
    int DecrementHP()
    {
        return HP - 1;
    }
}
