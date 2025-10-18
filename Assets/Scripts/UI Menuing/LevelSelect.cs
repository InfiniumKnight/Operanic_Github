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

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip preMenuClick; //clicking on the body part to go to the level confirmation
    [SerializeField] private AudioClip postMenuClick; //clicking on the body part to go to the level
    [SerializeField] private AudioClip closeMenu; //hitting close to go back


    // Start is called before the first frame update
    void Start()
    {
        ArmSelectUI.SetActive(false);
        TorsoSelectUI.SetActive(false);
    }
    public void ArmSelect()
    {
        audioSource.PlayOneShot(postMenuClick);
        SceneManager.LoadScene("LVL_ArtPrototype"); //Should be changed when Art Prototype is not the name of the Arm Level scene anymore
    }

    public void TorsoSelect()
    {
        audioSource.PlayOneShot(postMenuClick);
        SceneManager.LoadScene("LVL_Torso"); //Takes you to Torso level
    }

    public void PreArmSelect()
    {
        audioSource.PlayOneShot(preMenuClick);
        ArmSelectUI.SetActive(true); //Activates secondary UI to show gif of arm and start stage
    }

    public void UndoArmSelect()
    {
        audioSource.PlayOneShot(closeMenu);
        ArmSelectUI.SetActive(false); //Undoes the above
    }

    public void PreTorsoSelect()
    {
        audioSource.PlayOneShot(preMenuClick);
        TorsoSelectUI.SetActive(true); //Activates secondary UI to show gif of torso and start sage
    }

    public void UndoTorsoSelect()
    {
        audioSource.PlayOneShot(closeMenu);
        TorsoSelectUI.SetActive(false); //Undoes the above
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
