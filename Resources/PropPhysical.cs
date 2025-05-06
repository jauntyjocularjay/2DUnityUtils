using UnityEngine;

public class PropPhysical : Prop
{
    Rigidbody2D rb;
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }
    public Rigidbody2D Rigidbody2D()
    {
        return rb;
    }
    public void SetRigidbody2D(Rigidbody2D rb2d)
    {
        rb = rb2d;
    }
}
