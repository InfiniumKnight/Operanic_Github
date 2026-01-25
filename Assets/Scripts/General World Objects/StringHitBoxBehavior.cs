using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHitBoxBehavior : MonoBehaviour
{
    private Vector3 StartPosition;
    [SerializeField] float moveSpeed = 14f;

    private float Direction;

    private bool canMove = false;

    public void Start()
    {
        StartPosition = gameObject.transform.position;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            gameObject.transform.Translate(Vector3.back * Direction * moveSpeed * Time.deltaTime);
        }
    }

    public void Go(int direction)
    {
        Direction = direction;
        canMove = true;
        Debug.Log("Called");
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1f);
        canMove = false;
        gameObject.transform.position = StartPosition;
        gameObject.SetActive(false);
    }
}
