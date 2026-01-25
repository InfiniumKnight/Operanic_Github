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
    [SerializeField] AudioClip IncorrectSound;

    [SerializeField] private string GoalTag;

    [SerializeField] GameObject FallingGear;

    [SerializeField] Activation activation;
    public bool canMove = true;
    private bool canSpawnGear = true;

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
            audioSource.clip = SlideSound;
            audioSource.loop = true;
            audioSource.Play();
        }
        canSpawnGear = true;
        canMove = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = null;
            rb.velocity = new Vector3(0,0,0);
            canMove = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(canMove == true)
        {
            if (other.gameObject.tag == GoalTag)
            {
                activation.Activate();
                Debug.Log("reachGoal");
                audioSource.PlayOneShot(ClickIntoPlace);
                canMove = false;
            }
            else if (other.gameObject.tag != GoalTag && other.gameObject.tag.Contains("Goal"))
            {
                if (canSpawnGear == true)
                {
                    //audioSource.PlayOneShot(IncorrectSound);
                    Vector3 PlayerLocation = GameObject.FindWithTag("Player").transform.position;
                    Vector3 spawnLocation = new Vector3(PlayerLocation.x, PlayerLocation.y + 10f, PlayerLocation.z);
                    Instantiate(FallingGear, spawnLocation, Quaternion.identity);
                    canSpawnGear = false;
                }

            }
        }
    }

}
