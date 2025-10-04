using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swingingwire : MonoBehaviour
{
    [SerializeField] private float SwingSpeed = 20f;
    [SerializeField] private float TimeTillDirectionChange = 1.5f;
    [SerializeField] private float SinceChange;

    private float Direction = 1f;

    // Update is called once per frame
    void Update()
    {
        if ( SinceChange < TimeTillDirectionChange)
        {
            gameObject.transform.Rotate(new Vector3(Direction, 0, 0) * SwingSpeed * Time.deltaTime);
            SinceChange += Time.deltaTime;
        }
        else if ( SinceChange >= TimeTillDirectionChange)
        {
            Direction = Direction * -1;
            SinceChange = 0f;
        }
    }
}
