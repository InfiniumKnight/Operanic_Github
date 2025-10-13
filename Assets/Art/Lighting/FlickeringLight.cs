using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public GameObject[] flickeringLights;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 0.4f;

    void Start()
    {
        flickeringLights = GameObject.FindGameObjectsWithTag("FlickeringLight");

        for (int i = 0; i < flickeringLights.Length; i++)
        {
            Light lightComp = flickeringLights[i].GetComponent<Light>();
            if (lightComp != null)
            {
                StartCoroutine(Flicker(lightComp));
            }
        }
    }

    IEnumerator Flicker(Light lightComp)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
            lightComp.enabled = !lightComp.enabled;
        }
    }
}
