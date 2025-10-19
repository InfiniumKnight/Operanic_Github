using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoManager : GameManager
{
    [SerializeField] GameObject EndZone;



    public override void PuzzleDone(int PuzzleNum)
    {
        if(PuzzleNum == 1)
        {
            EndZone.SetActive(true);
        }
        else if(PuzzleNum == 2)
        {
            //Do something else
        }
        //so on and so forth
    }
}
