using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiOpponent : MonoBehaviour
{
    private Animator animator;

    public float speed = 20.0f;
    private GameObject target;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Ball");

        var step = speed * Time.deltaTime;

        animator.SetBool("IsMoving", true);
        if (gameObject.GetComponent<GetBallMP>().isStickToPlayer == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, step);
            gameObject.transform.LookAt(goal.transform);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            gameObject.transform.LookAt(target.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AIGoalDetectArea")
        {
            gameObject.GetComponent<GetBallMP>().AIShoot();
        }
    }
}
