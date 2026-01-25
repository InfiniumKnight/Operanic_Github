using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameModeUnlock : MonoBehaviour
{
    public GameObject SecondGameModeButton;
    // Start is called before the first frame update
    void Start()
    {
        GeneralDataSaver.LoadData();

        if (GeneralDataSaver.LevelOneDone && GeneralDataSaver.LevelTwoDone)
        {
            SecondGameModeButton.SetActive(true);
        }
        else
        {
            SecondGameModeButton.SetActive(false);
        }
    }

}
