using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazardBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.Respawn();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
