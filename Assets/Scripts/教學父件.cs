using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 教學父件 : MonoBehaviour
{
    

    [SerializeField] bool activated = false;
    [SerializeField] bool popIn = false;
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (activated)
        {
            animator.enabled = true;
            activated = false;
        }
            
    }

    public void AnimatorEndEvent()
    {
        if (popIn)
        {
            gameObject.SetActive(true);
            animator.enabled = true;
            popIn = false;
            animator.SetBool("PopIn", popIn);
        }
        else
        {
            animator.enabled = false;
            popIn = true;
            animator.SetBool("PopIn", popIn);
            gameObject.SetActive(false);
        }
            
        
        

        

    }

}
