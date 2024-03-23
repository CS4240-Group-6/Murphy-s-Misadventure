using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomInteractions : MonoBehaviour
{
    public Transform sturdyTableTransform;
    public Transform playerTransform;
    public float timeLimit = 60f;
    private float elapsedTime = 0f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    Earthquake scene related
    */


    void Update()
    {
        // Check if the game is already over
        if (isGameOver)
            return;

        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the time limit has been reached
        if (elapsedTime >= timeLimit)
        {
            EndGame(false); // User loses if time limit is exceeded
            return;
        }

        // Check if the user is below the table
        if (playerTransform.position.y < sturdyTableTransform.position.y)
        {
            EndGame(true); // User wins if below the table
        }
    }

    void EndGame(bool isWinner)
    {
        isGameOver = true;

        if (isWinner)
        {
            Debug.Log("Congratulations! You win!");
            // Implement logic for winning the level
        }
        else
        {
            Debug.Log("Time's up! You lose!");
            // Implement logic for losing the level
        }
    }



    /*
    Electrical Fire scene related
    */
}
