using UnityEngine;

public class SoundEffectMenu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public void Sound1() //click sound
    {
        src.clip = sfx1;
        src.Play();
    }

    public void Sound2() //exit sound
    {
        src.clip = sfx2;
        src.Play();
    }
}
