using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public PlayerController Controller;
    public Animator animator;

    public float moveSpeed = 5f;

    float horizontalMove = 0f;
    bool jump = false;
    //Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
           
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Isloling", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Isloling", false);
        }
       
    }
   /* public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }*/
    void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime,jump);
        jump = false;
        
    }
}
