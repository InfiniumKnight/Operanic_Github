using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneReloader : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        // Get the name of the currently active scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the scene with that name
        SceneManager.LoadScene(currentSceneName);
    }
}
