using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSequencePlayer : MonoBehaviour
{
    [SerializeField] private StringBehavior Parent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PunchBox")
        {
            Parent.PlaySequence();
        }
    }
}
