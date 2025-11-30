using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class GeneralDataSaver
{
    public static int HighScore;

    public static bool LevelOneDone = false;

    public static bool LevelTwoDone = false;

    public static void SaveData()
    {
        TempDataHolder Temp = new TempDataHolder();

        Temp.HighScore = HighScore;
        Temp.LevelOneDone = LevelOneDone;
        Temp.LevelTwoDone = LevelTwoDone;

        string json = JsonUtility.ToJson(Temp);

        string path = Application.persistentDataPath + "/SavedData.json";

        System.IO.File.WriteAllText(path, json);
    }

    public static void LoadData()
    {
        string path = Application.persistentDataPath + "/SavedData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            TempDataHolder loadedData = JsonUtility.FromJson<TempDataHolder>(json);

            HighScore = loadedData.HighScore;
            LevelOneDone = loadedData.LevelOneDone;
            LevelTwoDone = loadedData.LevelTwoDone;
        }
        else
        {
            Debug.LogWarning("File not found!");
        }
    }
}
