using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringBehavior : MonoBehaviour
{ 
    [Header("GameObjectArrays")]
    [SerializeField] private List<GameObject> CorrectOrder;
    [SerializeField] private List<GameObject> InputedOrder;
    [SerializeField] private int NumHitsRegistered;

    [Header("Materials")]
    [SerializeField] private Material BaseColor;
    [SerializeField] private Material FlashMaterial;
    [SerializeField] private Material CorrectColor;
    [SerializeField] private Material IncorrectColor;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip CorrectSound;
    [SerializeField] private AudioClip IncorrectSound;

    [Header("General Variables")]
    [SerializeField] private float SequencePlaySpeed;
    [SerializeField] private int PuzzleNum;
    [SerializeField] private GameManager gameManager;

    private int NumCorrect;

    private void Update()
    {
        if ( NumHitsRegistered >= CorrectOrder.Count)
        {
            for (int b = 0; b < CorrectOrder.Count; b++)
            {
                if (CorrectOrder[b].gameObject.GetComponent<StringPunch>().StringNum != InputedOrder[b].gameObject.GetComponent<StringPunch>().StringNum)
                {
                    audioSource.PlayOneShot(IncorrectSound);
                    for (int x = 0; x < CorrectOrder.Count; x++)
                    {
                        CorrectOrder[x].gameObject.GetComponent<MeshRenderer>().material = IncorrectColor;
                        StartCoroutine(Delay2());
                    }
                    NumHitsRegistered = 0;
                    NumCorrect = 0;
                    InputedOrder.Clear();
                    break;
                }
                else if (CorrectOrder[b].gameObject.GetComponent<StringPunch>().StringNum == InputedOrder[b].gameObject.GetComponent<StringPunch>().StringNum)
                {
                    NumCorrect++;
                }
            }

            if(NumCorrect == CorrectOrder.Count)
            {
                audioSource.PlayOneShot(CorrectSound);
                gameManager.PuzzleDone(PuzzleNum);
                for (int x = 0; x < CorrectOrder.Count; x++)
                {
                    CorrectOrder[x].gameObject.GetComponent<MeshRenderer>().material = CorrectColor;
                    NumHitsRegistered = 0;
                    
                }
            }

        }
    }
    public void PlaySequence()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        for (int i = 0; i < CorrectOrder.Count; i++)
        {
            CorrectOrder[i].gameObject.GetComponent<MeshRenderer>().material = FlashMaterial;
            CorrectOrder[i].gameObject.GetComponent<StringPunch>().PlayTone();
            yield return new WaitForSecondsRealtime(SequencePlaySpeed);
            CorrectOrder[i].gameObject.GetComponent<MeshRenderer>().material = BaseColor;
            
        }
    }

    public void AddToOrder(GameObject String)
    {
        InputedOrder.Add(String);
        NumHitsRegistered++;
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSecondsRealtime(.5f);
        for (int x = 0; x < CorrectOrder.Count; x++)
        {
            CorrectOrder[x].gameObject.GetComponent<MeshRenderer>().material = BaseColor;
            CorrectOrder[x].gameObject.GetComponent<StringPunch>().CanBePunched = true;
        }
    }
}
