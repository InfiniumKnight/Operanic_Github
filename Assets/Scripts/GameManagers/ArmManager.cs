using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : GameManager
{
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public override void PuzzleDone(int PuzzleNum)
    {
        if (PuzzleNum == 1)
        {
            Destroy(rb);
        }
        else if (PuzzleNum == 2)
        {
            //Do something else
        }
        //so on and so forth
    }
}
