using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LVL_ArtPrototype");
    }

        public void LevelSelect()
    {
        SceneManager.LoadScene("LVL_LevelSelect");
    }
}
