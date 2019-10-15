using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBord : MonoBehaviour
{
    private Animator animator;
 
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Open", true);
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("Open", false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "hand")
        {
            if(!animator.GetBool("Open"))
                animator.SetBool("Open", true);
            else
                animator.SetBool("Open", false);
        }    
    }

  

}
