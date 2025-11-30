using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode2Teleport : MonoBehaviour
{
    [SerializeField] Material BaseColor;
    [SerializeField] Material ActiveColor;
    [SerializeField] Vector3 TeleportPosition;
    public bool TeleportActive = false;


    public void Activate()
    {
        TeleportActive = true;
        gameObject.GetComponent<MeshRenderer>().material = ActiveColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TeleportActive == true)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Teleported");
                other.gameObject.GetComponent<CharacterController>().enabled = false;
                other.gameObject.transform.position = TeleportPosition;
                other.gameObject.GetComponent<CharacterController>().enabled = true;
                TeleportActive = false;
                gameObject.GetComponent<MeshRenderer>().material = BaseColor;
            }
        }
        
    }
}
