using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringBehavior : MonoBehaviour
{
    [Header("GameObjectArrays")]
    [SerializeField] private List<GameObject> CorrectOrder;
    [SerializeField] private List<GameObject> InputedOrder;
    [SerializeField] private int NumHitsRegistered;

    [Header("Hazard Objects")]
    [SerializeField] GameObject HitboxOne;
    [SerializeField] GameObject HitboxTwo;

    [Header("Materials")]
    [SerializeField] private Material BaseColor;
    [SerializeField] private Material FlashMaterial;
    [SerializeField] private Material CorrectColor;
    [SerializeField] private Material IncorrectColor;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip CorrectSound;
    [SerializeField] private AudioClip IncorrectSound;
    [SerializeField] private AudioSource BackgroundLayer;

    [Header("General Variables")]
    [SerializeField] private float SequencePlaySpeed;
    [SerializeField] private int PuzzleNum;
    [SerializeField] private GameManager gameManager;

    private int NumCorrect;

    private void Update()
    {
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
        int b = InputedOrder.Count - 1;
        NumHitsRegistered++;

        if (CorrectOrder[b].gameObject.GetComponent<StringPunch>().StringNum != InputedOrder[b].gameObject.GetComponent<StringPunch>().StringNum)
        {
            audioSource.PlayOneShot(IncorrectSound);
            for (int x = 0; x < CorrectOrder.Count; x++)
            {
                CorrectOrder[x].gameObject.GetComponent<MeshRenderer>().material = IncorrectColor;
                StartCoroutine(Delay2());
            }
            Penalty();
            NumHitsRegistered = 0;
            NumCorrect = 0;
            InputedOrder.Clear();
        }

        else if (NumHitsRegistered >= CorrectOrder.Count)
        {
                audioSource.PlayOneShot(CorrectSound);
                gameManager.PuzzleDone(PuzzleNum);
                for (int x = 0; x < CorrectOrder.Count; x++)
                {
                    CorrectOrder[x].gameObject.GetComponent<MeshRenderer>().material = CorrectColor;
                    NumHitsRegistered = 0;
                    BackgroundLayer.volume = .5f;

                }
        }
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

    private void Penalty()
    {
        HitboxOne.SetActive(true);
        HitboxTwo.SetActive(true);

        HitboxOne.GetComponent<StringHitBoxBehavior>().Go(1);
        HitboxTwo.GetComponent<StringHitBoxBehavior>().Go(-1);
    }
}
