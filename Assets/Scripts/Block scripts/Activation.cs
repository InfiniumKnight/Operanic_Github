using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] private int numOfActivationsNeeded = 1;
    [SerializeField] private int PuzzleNum;
    //[SerializeField] private GameManager gameManager;
    private int numOfActivationsAchieved;

    public void Activate()
    {
        numOfActivationsAchieved++;
        if (numOfActivationsAchieved >= numOfActivationsNeeded)
        {
            //gameManager.PuzzleDone(PuzzleNum);
        }
    }
}
