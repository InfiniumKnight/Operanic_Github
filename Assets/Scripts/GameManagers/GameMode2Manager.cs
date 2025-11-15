using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMode2Manager : GameManager
{
    [Header("TimeVariables")]
    [SerializeField] float startTime = 10.0f;
    [SerializeField] float RemainingTime = 10.0f;
    [SerializeField] int TimeRegained = 3;
    [SerializeField] float TimeTillNextPuzzle = 2;

    [Header("PuzzleObjects")]
    [SerializeField] Activation Puzzle1;
    [SerializeField] Activation Puzzle2;
    [SerializeField] StringBehavior Puzzle3;
    [SerializeField] StringBehavior Puzzle4;

    [Header("TeleportPads")]
    [SerializeField] List<GameMode2Teleport> HubPads;
    [SerializeField] List<GameMode2Teleport> PuzzleLeavePads;

    [Header("Score")]
    [SerializeField] int Score;
    public static int HighScore;

    private void Start()
    {
        RemainingTime = startTime;
        PuzzleSelect();
    }

    private void Update()
    {
        if(RemainingTime >= 0)
        {
            RemainingTime -= Time.deltaTime;
        }
        if(RemainingTime <= 0)
        {
            LooseState();
        }
    }

    public override void PuzzleDone(int PuzzleNum)
    {
        RemainingTime += TimeRegained;
        Score++;
        if (PuzzleNum == 1)
        {
            PuzzleLeavePads[0].Activate();
        }
        if (PuzzleNum == 2)
        {
            PuzzleLeavePads[1].Activate();
        }
        if (PuzzleNum == 3)
        {
            PuzzleLeavePads[2].Activate();
        }
        if (PuzzleNum == 4)
        {
            PuzzleLeavePads[3].Activate();
        }
        StartCoroutine(Delay());
        
    }

    public void LooseState()
    {
        Debug.Log("Game Over!");
        if(Score > HighScore)
        {
            HighScore = Score;
        }
        SceneManager.LoadScene("TEMP_LevelFinish");
    }

    public void PuzzleSelect()
    {
        int RandomPuzzle = Random.Range(0, 4);
        if(RandomPuzzle == 0)
        {
            Puzzle1.Reset();
            HubPads[RandomPuzzle].Activate();
        }
        if (RandomPuzzle == 1)
        {
            Puzzle2.Reset();
            HubPads[RandomPuzzle].Activate();
        }
        if (RandomPuzzle == 2)
        {
            Puzzle3.Reset();
            HubPads[RandomPuzzle].Activate();
        }
        if (RandomPuzzle == 3)
        {
            Puzzle4.Reset();
            HubPads[RandomPuzzle].Activate();
        }
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(TimeTillNextPuzzle);
        PuzzleSelect();
        Debug.Log("PuzzleSelected");

    }
}
