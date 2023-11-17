using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText; // Reference to the Text element 
    public Text healthText; // Reference to another Text element 


    // Declare variables 
    private int playerScore = 0;
    private float playerHealth = 100.0f;

    public GameObject box;  //1 
    public GameObject position; //2
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //5 
        {
            print("space key was pressed"); //6 
            Instantiate(box, position.transform); //7 
        }
        // Test if the score is greater than or equal to 100 
        if (playerScore >= 100)
        {
            // Display a message when the score reaches 100 
            scoreText.text = "Score: 100 (You Win!)";
        }

        // Detect a key press (e.g., "W" key) 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Increase the score when the "W" key is pressed 
            playerScore += 10;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Decrease the score when the "X" key is pressed
            playerScore -= 10;
        }
        // Update the Text elements with current values 
        scoreText.text = "Score: " + playerScore.ToString();
        healthText.text = "Health: " + playerHealth.ToString();
    }


    public void IncreaseScore(int increaseScoreBy)
    {
        playerScore += increaseScoreBy;
        scoreText.text = "Score: " + playerScore;
    }



}
