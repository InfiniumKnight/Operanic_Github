using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDestroyCollision : MonoBehaviour
{
    public GameObject objectToDestroy; // Assign the third object in the Inspector

    void OnTriggerEnter(Collider other)
    {
        // Check if Object 2 (the object that entered the trigger) has a specific tag
        if (other.gameObject.CompareTag("MovingBlock"))
        {
            // Destroy the third object
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
        }
    }
}
