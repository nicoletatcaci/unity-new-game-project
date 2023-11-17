using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AgentScript : MonoBehaviour
{
    public Animator animator;  
    public Transform goal; 
    NavMeshAgent agent;  
    bool isDead = false; //1
    GameController gameControllerInstance; // This will hold the reference to the GameController script.

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Get the GameController component from the GameController GameObject in the scene.
        gameControllerInstance = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
        if (isDead == false) { //2
            animator.SetFloat("Speed_f", agent.velocity.magnitude);
        }  
    }

    private void OnTriggerEnter(Collider other) //3 
    {
        if (other.tag == "bullet") //4
        {
            animator.SetInteger("DeathType_int", 1); //5 
            animator.SetBool("Death_b", true); //6 
            isDead = true; //7
            agent.speed = 0; //8
            gameControllerInstance.IncreaseScore(100); // Assuming GameController has a method to increase the score.

        }

    }

 }


