using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce = 10.0f;
    public Animator animator;
    public Transform groundCheckTransform; // A reference to an empty GameObject placed at the character's feet
    public LayerMask groundLayer; // The layer(s) that represent the grounds

    public float speed = 10.0f;
    // Start is called before the first frame update 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
      

        float x = Input.GetAxis("Horizontal"); //1 
        float z = Input.GetAxis("Vertical"); //2 

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime; //3
        animator.SetFloat("Speed_f", move.magnitude);
        transform.position += move;
    }

    void jump(Vector3 horizontalMovement)
    {
        bool isGrounded = Physics.Raycast(groundCheckTransform.position, Vector3.down, 0.1f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump_b", true);
        }

        else if (Input.GetButtonUp("Jump"))

        {
            animator.SetBool("Jump_b", false);
        }



    }
}