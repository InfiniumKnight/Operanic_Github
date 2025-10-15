using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPunch : MonoBehaviour
{
    [SerializeField] StringBehavior parent;
    [SerializeField] GameObject self;
    [SerializeField] Material punchedColor;
    [SerializeField] AudioSource audioSource;
    public int StringNum;

    public bool CanBePunched = true;

    private void Start()
    {
        self = gameObject;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CanBePunched == true)
        {
            if (other.gameObject.tag == "PunchBox")
            {
                self.gameObject.GetComponent<MeshRenderer>().material = punchedColor;
                parent.AddToOrder(self);
                CanBePunched = false;
            }
        }
    }
}
