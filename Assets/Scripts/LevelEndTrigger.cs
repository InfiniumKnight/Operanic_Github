using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) //Only activates if it collides with Player tag
        {
            SceneManager.LoadScene("LVL_LevelFinish"); //Automatically takes back to temp win screen, should be changed to animate back to hub menu later
        }
    }
}
