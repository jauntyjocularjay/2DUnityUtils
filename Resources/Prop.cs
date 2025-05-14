using UnityEngine;




[ExecuteAlways]
public abstract class Prop : MonoBehaviour
{
    Transform tx;
    SpriteRenderer sr;
    Rigidbody2D rb;

    
    public void Start()
    {
        SetTransform();
        SetSpriteRenderer();
    }
    
    public void SetTransform()
    {
        tx = GetComponent<Transform>();
    }
    public Transform Transform()
    {
        return tx;
    }

    public void SetPosition(Vector2 v)
    {
        tx.position = v;
    }
    public void SetXPositionX(float f)
    {
        tx.position = new Vector2(f, tx.position.y);
    }

    public void SetPositionY(float f)
    {
        tx.position = new Vector2(tx.position.x, f);
    }

    public void SetTransform(Vector3 position, Quaternion rotation)
    {
        Transform().SetPositionAndRotation(position, rotation);
    }

    public void SetSpriteRenderer()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public SpriteRenderer SpriteRenderer()
    {
        return sr;
    }
    public void SetSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }
    
    public Sprite Sprite()
    {
        return sr.sprite;
    }
    public Vector2 PivotPoint()
    {
        return sr.sprite.pivot;
    }


    public Rigidbody2D Rigidbody2D()
    {
        return rb;
    }
}
