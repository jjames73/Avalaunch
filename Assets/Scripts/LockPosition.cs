using UnityEngine;

public class LockPosition : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 fixedPosition = rb.position;
        fixedPosition.y = 0; // Lock Y position
        rb.MovePosition(fixedPosition);
    }
}