using UnityEngine;

public class Rotator2D : MonoBehaviour
{
    Quaternion endQuaternion;
    public Vector3 endRotation;
    public float rotationSpeed = 0.01f;
    public BoxCollider2D trigger;
    float timeCount = 0.0f;
    public bool startRotation;
    // The graphic needs to be on a child of the Rotator Game Object.

    void Start()
    {
        endQuaternion = Quaternion.Euler(endRotation);
        trigger.isTrigger = true;
    }

    void Update()
    {
        if(startRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, endQuaternion, timeCount * rotationSpeed);
            timeCount += Time.deltaTime;
            if (transform.rotation == endQuaternion)
                startRotation = false;
        }
    }
}