using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] private int numOfActivationsNeeded = 1;
    [SerializeField] private int PuzzleNum;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<GameObject> Blocks;
    [SerializeField] private List<Vector3> StartingPositions;
    [SerializeField] private List<AudioSource> backgroundSources;
    private int BackgroundIndex = 0;
    private int numOfActivationsAchieved;
    public bool BackgroundMusic = true;

    public void Activate()
    {
        if (BackgroundMusic == true)
        {
            backgroundSources[BackgroundIndex].volume = .1f;
            BackgroundIndex++;
        }
        numOfActivationsAchieved++;
        if (numOfActivationsAchieved >= numOfActivationsNeeded)
        {
            Debug.Log("Disabling Puzzle 1 wall");
            gameManager.PuzzleDone(PuzzleNum);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < Blocks.Count; i++)
        {
            Blocks[i].transform.position = StartingPositions[i];
            Blocks[i].GetComponent<BlockBehavior>().canMove = true;
        }
    }
}
