using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPunch : MonoBehaviour
{
    [SerializeField] StringBehavior parent;
    [SerializeField] GameObject self;
    [SerializeField] Material punchedColor;
    public int StringNum;

    public bool CanBePunched = true;

    private void Start()
    {
        self = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PunchBox")
        {
            self.gameObject.GetComponent<MeshRenderer>().material = punchedColor;
            parent.AddToOrder(self);
            CanBePunched = false;
        }
    }
}
