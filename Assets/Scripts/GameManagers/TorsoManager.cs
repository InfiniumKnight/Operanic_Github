using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoManager : GameManager
{
    [SerializeField] GameObject Platforms;
    [SerializeField] GameObject EndZone;



    public override void PuzzleDone(int PuzzleNum)
    {
        if(PuzzleNum == 1)
        {
            Platforms.SetActive(true);
        }
        else if(PuzzleNum == 2)
        {
            EndZone.SetActive(true);
        }
        //so on and so forth
    }
}
