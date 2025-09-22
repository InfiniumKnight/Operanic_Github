using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBox : MonoBehaviour
{
    [SerializeField] private BlockBehavior ParentBox;
    [SerializeField] private int direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PunchBox")
        {
            Debug.Log("Punched");
            ParentBox.Punched(direction);
        }
    }

}
