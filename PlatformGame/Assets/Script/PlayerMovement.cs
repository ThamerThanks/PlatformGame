using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (horizontalMove != 0 && !FindObjectOfType<AudioManager>().IsPlaying("PlayerWalk"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerWalk");
            
        }
        else if (horizontalMove == 0 && FindObjectOfType<AudioManager>().IsPlaying("PlayerWalk"))
        {
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
        }
    }
    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


        
    }
}
