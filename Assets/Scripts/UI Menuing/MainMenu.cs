using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound; // click
    [SerializeField, Range(0f, 1f)] private float volume = 0.5f;

    public void PlayGame()
    {
        StartCoroutine(PlayThenLoad());
    }

    private IEnumerator PlayThenLoad()
    {
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound, volume);
            yield return new WaitForSecondsRealtime(clickSound.length);
        }

        SceneManager.LoadScene("LVL_ArtPrototype");
    }

    public void QuitGame()
    {
        Debug.Log("You Quit The Game");
        Application.Quit();
    }
}
