using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI_Pause;
    public GameObject UI_InGame;
    public bool isPaused;

    /*[Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound; //for clicking on a menu part while paused
    [SerializeField] private AudioClip backSound; //for clicking back to the game
    [SerializeField] private AudioClip pauseSound; //for pausing at all
    [SerializeField] private float Volume = 50;*/


    // Start is called before the first frame update
    void Start()
    {
        UI_Pause.SetActive(false);
        //Time.timeScale = 0;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.volume = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                //audioSource.PlayOneShot(backSound);
            }
            else
            {
                PauseGame();
                //audioSource.PlayOneShot(pauseSound);
            }
        }
    }

    public void PauseGame()
    {
        UI_Pause.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        UI_InGame.SetActive(false);
    }

    public void ResumeGame()
    {
        UI_Pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        UI_InGame.SetActive(true);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        //audioSource.PlayOneShot(backSound);
        SceneManager.LoadScene("LVL_LevelSelect");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
