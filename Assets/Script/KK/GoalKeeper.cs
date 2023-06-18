using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public GameObject target1, target2;
    public float speed;
    private bool moveToTarget1 = true;
    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = target1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the current target position
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Check if the object has reached the current target position
        if (transform.position == currentTarget)
        {
            // Switch the target position
            if (moveToTarget1)
            {
                currentTarget = target2.transform.position;
            }
            else
            {
                currentTarget = target1.transform.position;
            }

            moveToTarget1 = !moveToTarget1;
        }
    }
}
