using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    [SerializeField] private float SlideSpeed = 30f;
    [SerializeField] private Rigidbody rb;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip SlideSound;
    [SerializeField] AudioClip ClickIntoPlace;

    [SerializeField] private string GoalTag;

    [SerializeField] Activation activation;
    private bool canMove = true;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Punched(int direction)
    {
        //Debug.Log("Punch Registered");
        if (canMove)
        {
            if (direction == 1)//north hit box, pushes south
            {
                rb.velocity = new Vector3(0, 0, -1 * SlideSpeed * Time.deltaTime);
            }
            else if (direction == 2)//east hitbox, pushes west
            {
                rb.velocity = new Vector3(-1 * SlideSpeed * Time.deltaTime, 0, 0);
            }
            else if (direction == 3)//south hitbox, pushes north
            {
                rb.velocity = new Vector3(0, 0, 1 * SlideSpeed * Time.deltaTime);
            }
            else if (direction == 4)//west hitbox, pushes east
            {
                rb.velocity = new Vector3(1 * SlideSpeed * Time.deltaTime, 0, 0);
            }
            //audioSource.clip = SlideSound;
            //audioSource.loop = true;
            //audioSource.Play();
        }
        canMove = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            //audioSource.Stop();
            //audioSource.loop = false;
            //audioSource.clip = null;
            rb.velocity = new Vector3(0,0,0);
            canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canMove == true)
        {
            if (other.gameObject.tag == GoalTag)
            {
                activation.Activate();
                Debug.Log("reachGoal");
                //audioSource.PlayOneShot(ClickIntoPlace);
                Destroy(rb);
                canMove = false;
            }
        }
    }

}
