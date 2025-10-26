using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoManager : GameManager
{
    [SerializeField] GameObject Platforms;
    [SerializeField] GameObject Platforms2;
    [SerializeField] GameObject EndZone;



    public override void PuzzleDone(int PuzzleNum)
    {
        if(PuzzleNum == 1)
        {
            Platforms.SetActive(true);
        }
        else if(PuzzleNum == 2)
        {
            Platforms2.SetActive(true);
        }
        else if(PuzzleNum == 3){
            EndZone.SetActive(true);
        }
    }
}
