using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : GameManager
{
    [SerializeField] List<GameObject> PuzzleBarriers;

    public override void PuzzleDone(int PuzzleNum)
    {
        if (PuzzleNum == 1)
        {
            
            PuzzleBarriers[0].SetActive(false);
        }
        else if (PuzzleNum == 2)
        {
            PuzzleBarriers[1].SetActive(false);
        }
        //so on and so forth
    }
}
