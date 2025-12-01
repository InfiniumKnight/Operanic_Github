using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScreen : MonoBehaviour
{

    public GameObject UI_HighScoreScreen;
    public GameObject UI_InGame;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        UI_HighScoreScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
