using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] private int numOfActivationsNeeded = 1;
    [SerializeField] private int PuzzleNum;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<AudioSource> backgroundSources;
    private int BackgroundIndex = 0;
    private int numOfActivationsAchieved;

    public void Activate()
    {
        backgroundSources[BackgroundIndex].volume = .75f;
        BackgroundIndex++;
        numOfActivationsAchieved++;
        if (numOfActivationsAchieved >= numOfActivationsNeeded)
        {
            Debug.Log("Disabling Puzzle 1 wall");
            gameManager.PuzzleDone(PuzzleNum);
        }
    }
}
