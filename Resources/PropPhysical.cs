using UnityEngine;

public class PropPhysical : Prop
{
    Rigidbody2D rb;
    new void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    Rigidbody2D Rigidbody2D()
    {
        return rb;
    }
    void SetRigidbody2D(Rigidbody2D rb2d)
    {
        rb = rb2d;
    }
}
