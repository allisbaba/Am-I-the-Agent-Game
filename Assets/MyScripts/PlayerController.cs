using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float Grounddistance = 0.3f;

    
    public float jumpHeight;
    public float gravity;

    public float originalHeight;
    public float crouchHeight;

    public LayerMask GroundMask;

   

    private void Update()
    {
        #region Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        #endregion

        

        #region Basic Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }

        #endregion

        isGrounded = Physics.CheckSphere(groundCheck.position, Grounddistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
