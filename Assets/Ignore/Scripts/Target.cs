using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // This function is called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is a prefab (you can change the tag as needed)
        if (collision.gameObject.CompareTag("Target"))
        {
            // Destroy the colliding object
            Destroy(collision.gameObject);
        }
    }
}
