using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPipe : MonoBehaviour
{
    [SerializeField] private GameObject SteamHitBox;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SteamSound;

    public float DelayBetweenBlasts = 4f;
    public float BlastDuration = .5f;

    private float SincelastBlast;

    void Start()
    {
        SteamHitBox.SetActive(false);
        audioSource.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ( SincelastBlast < DelayBetweenBlasts )
        {
            SincelastBlast += Time.deltaTime;
        }
        else if ( SincelastBlast >= DelayBetweenBlasts)
        {
            
            StartCoroutine(Delay());
            SincelastBlast = 0;

        }
    }

    IEnumerator Delay()
    {
        SteamHitBox.SetActive(true);
        audioSource.PlayOneShot(SteamSound);
        yield return new WaitForSecondsRealtime(BlastDuration);
        SteamHitBox.SetActive(false);
        audioSource.Stop();
        
    }
}
