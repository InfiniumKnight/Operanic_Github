using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public bool ArmLevel = false;
    public bool TorsoLevel = false;

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) //Only activates if it collides with Player tag
        {
            if (ArmLevel)
            {
                GeneralDataSaver.LevelOneDone = true;
            }
            else if (TorsoLevel)
            {
                GeneralDataSaver.LevelTwoDone = true;
            }
            GeneralDataSaver.SaveData();
            SceneManager.LoadScene("LVL_LevelSelect"); //Automatically takes back to temp win screen, should be changed to animate back to hub menu later
        }
    }
}
