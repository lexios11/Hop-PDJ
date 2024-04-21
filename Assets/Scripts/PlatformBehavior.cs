using Unity.VisualScripting;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    public float maxSpeed = 5f; // Maximum speed in units per second
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the velocity magnitude exceeds the maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            // Limit the velocity to the maximum speed
            rb.velocity = rb.velocity.normalized / maxSpeed;
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }
}
