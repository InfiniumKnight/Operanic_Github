using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] private int numOfActivationsNeeded = 1;
    private int numOfActivationsAchieved;

    public void Activate()
    {
        numOfActivationsAchieved++;
        if (numOfActivationsAchieved >= numOfActivationsNeeded)
        {
            gameObject.transform.position = new Vector3(21.5f, 53.35f, 39.44f);
        }
    }
}
