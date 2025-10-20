using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPipe : MonoBehaviour
{
    [SerializeField] private GameObject SteamHitBox;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SteamSound;

    public float DelayBetweenBlasts = 1f;
    public float BlastDuration = .5f;

    private float SincelastBlast;

    void Start()
    {
        SteamHitBox.SetActive(false);
    }

    void Update()
    {
        if ( SincelastBlast < DelayBetweenBlasts )
        {
            SincelastBlast += Time.deltaTime;
        }
        else if ( SincelastBlast >= DelayBetweenBlasts)
        {
            SteamHitBox.SetActive(true);
            StartCoroutine(Delay());

        }
    }

    IEnumerator Delay()
    {
        audioSource.PlayOneShot(SteamSound);
        yield return new WaitForSecondsRealtime(BlastDuration);
        SteamHitBox.SetActive(false);
        SincelastBlast = 0;
    }
}
