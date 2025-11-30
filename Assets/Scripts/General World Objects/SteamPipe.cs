using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPipe : MonoBehaviour
{
    [SerializeField] private GameObject SteamHitBox;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SteamSound;
    [SerializeField] private ParticleSystem SteamVFX;

    public float DelayBetweenBlasts = 4f;
    public float BlastDuration = .5f;

    private float SincelastBlast;

    void Start()
    {
        SteamHitBox.SetActive(false);
        audioSource.volume = 0.5f;
        StartCoroutine(Delay2());
        SteamVFX.Stop();

    }

    IEnumerator Delay()
    {
        SteamHitBox.SetActive(true);
        audioSource.PlayOneShot(SteamSound);
        yield return new WaitForSecondsRealtime(BlastDuration);
        SteamVFX.Stop();
        SteamHitBox.SetActive(false);
        audioSource.Stop();
        StartCoroutine(Delay2());
    }

    IEnumerator Delay2()
    {
        StartCoroutine(VFXDelay());
        yield return new WaitForSecondsRealtime(DelayBetweenBlasts);
        
        StartCoroutine(Delay());
    }

    IEnumerator VFXDelay()
    {
        yield return new WaitForSecondsRealtime(DelayBetweenBlasts - 0.7f);
        SteamVFX.Play();
    }
}
