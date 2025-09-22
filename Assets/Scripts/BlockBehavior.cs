using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    [SerializeField] private float SlideSpeed = 30f;
    [SerializeField] private Rigidbody rb;
    private bool canMove = true;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Punched(int direction)
    {
        //Debug.Log("Punch Registered");
        if (canMove)
        {
            if (direction == 1)
            {
                rb.velocity = new Vector3(0, 0, -1 * SlideSpeed * Time.deltaTime);
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector3(-1 * SlideSpeed * Time.deltaTime, 0, 0);
            }
            else if (direction == 3)
            {
                rb.velocity = new Vector3(0, 0, 1 * SlideSpeed * Time.deltaTime);
            }
            else if (direction == 4)
            {
                rb.velocity = new Vector3(1 * SlideSpeed * Time.deltaTime, 0, 0);
            }
        }
        canMove = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            rb.velocity = new Vector3(0,0,0);
            canMove = true;
        }
    }

}
