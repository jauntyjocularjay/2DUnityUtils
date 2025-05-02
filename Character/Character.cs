using System.Collections;
using UnityEngine;




public abstract class Character : Prop
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    [Header("Variables Character")]
    private int MaxHP = 5;
    private int hp = 0;
    new public void Start()
    {
        base.Start();
        SetSpriteRenderer();
        animator = GetComponent<Animator>();
        SetRigidbody2D();
        SetHP(MaxHP);
    }
    public Animator Animator()
    {
        return animator;
    }
    public abstract void SetCollider2D();
    public void SetRigidbody2D()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        rigidBody.freezeRotation = true;
    }
    public Rigidbody2D RigidBody2D()
    {
        return rigidBody;
    }
    public void SetHP(int currentHP)
    {
        hp = currentHP;
    }
    public int HP()
    {
        return hp;
    }
    public void LinearVelocityX(float x)
    {
        rigidBody.linearVelocity = new Vector2
        (
            x,
            rigidBody.linearVelocityY
        );
    }
    public void LinearVelocityY(float y)
    {
        rigidBody.linearVelocity = new Vector2
        (
            rigidBody.linearVelocityX,
            y
        );
    }
    public void LinearVelocity(Vector2 vector)
    {
        rigidBody.linearVelocity = vector;
    }

    
}
