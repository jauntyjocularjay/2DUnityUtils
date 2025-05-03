using System.Collections;
using UnityEngine;



public abstract class BoxPlayer: BoxCharacter
{
    [SerializeField] BoxPlayerData data;
    new Camera camera;
    public new void Start()
    {
        base.Start();
        camera = camera = Camera.main;
        SetCollider2D();
        SetRigidbody2D();

        BoxCollider2D().offset = data.colliderOffset;
        BoxCollider2D().size = data.colliderSize;
        
        RigidBody2D().mass = data.mass;
        RigidBody2D().gravityScale = data.gravityScale;

        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;

        SpriteRenderer().sortingLayerID = data.sortingLayerID;
        SpriteRenderer().sortingOrder = data.sortingOrder;
    }

    public void Update()
    {
        camera.GetComponent<Transform>().position = new Vector3(Transform().position.x, Transform().position.y + 3.75f, -10.0f);
    }
}
