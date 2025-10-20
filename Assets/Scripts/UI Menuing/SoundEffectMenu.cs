using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuSFXAndLoad : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource src;
    public AudioClip clickSfx;  
    public AudioClip backSfx;   

    // Loading Scenes Button "Play" "Level Select"
    public void PlayClickAndLoad(string sceneName)
    {
        StartCoroutine(PlayThenLoad(clickSfx, sceneName));
    }

    public void PlayBackAndLoad(string sceneName)
    {
        StartCoroutine(PlayThenLoad(backSfx, sceneName));
    }

    private IEnumerator PlayThenLoad(AudioClip clip, string sceneName)
    {
        if (clip != null) src.PlayOneShot(clip);

        // Fallback if clip is null
        float wait = clip != null ? clip.length : 0f;
        yield return new WaitForSecondsRealtime(wait);

        SceneManager.LoadScene(sceneName);
    }

    // Normal Buttons that doesnt load scenes
    public void PlayClick() { if (clickSfx) src.PlayOneShot(clickSfx); }
    public void PlayBack()  { if (backSfx)  src.PlayOneShot(backSfx);  }
}
