using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plakGoalKeeper : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int i;
        i = Random.Range(0, 1);

        print(i);
        print("blocking");

        if(other.tag == "Ball")
        {
            if(i == 0)
            {
                animator.SetBool("blockRight", true);
            }
            else
            {
                animator.SetBool("blockLeft", true);
            }
            
        }
        //animator.SetBool("blockRight", false);
        //animator.SetBool("blockLeft", false);


    }
}
