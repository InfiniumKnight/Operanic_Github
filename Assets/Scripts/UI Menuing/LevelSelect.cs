using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class LevelSelect : MonoBehaviour
{
    public GameObject ArmSelectUI;
    public GameObject TorsoSelectUI;

    // Start is called before the first frame update
    void Start()
    {
        ArmSelectUI.SetActive(false);
        TorsoSelectUI.SetActive(false);
    }
    public void ArmSelect()
    {
        SceneManager.LoadScene("LVL_ArtPrototype"); //Should be changed when Art Prototype is not the name of the Arm Level scene anymore
    }

    public void TorsoSelect()
    {
        SceneManager.LoadScene("LVL_Torso"); //Takes you to Torso level
    }

    public void PreArmSelect()
    {
        ArmSelectUI.SetActive(true); //Activates secondary UI to show gif of arm and start stage
    }

    public void UndoArmSelect()
    {
        ArmSelectUI.SetActive(false); //Undoes the above
    }

    public void PreTorsoSelect()
    {
        TorsoSelectUI.SetActive(true); //Activates secondary UI to show gif of torso and start sage
    }

    public void UndoTorsoSelect()
    {
        TorsoSelectUI.SetActive(false); //Undoes the above
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
