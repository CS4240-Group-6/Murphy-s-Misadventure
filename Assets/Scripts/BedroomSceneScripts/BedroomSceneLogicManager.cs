using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomSceneLogicManager : MonoBehaviour
{
    public Transform sturdyTableTransform;
    public Transform playerTransform;
    private LevelTextManager levelTextManager;
    private BedroomEmergencies bedroomEmergencies;
    public float timeLimit = 60f;
    private float elapsedTime = 0f;
    private bool gameOver = false;
    private float gameOverTimer = 0f;
    private float gameOverDelay = 1f; // 1 second delay before changing scene

    // Start is called before the first frame update
    void Start()
    {
        levelTextManager = GetComponent<LevelTextManager>();
        bedroomEmergencies = GetComponent<BedroomEmergencies>();
    }

    /*
    Earthquake scene related
    */


    void Update()
    {
        CheckGameOver();
        CheckLevelComplete();
        // // Check if the game is already over
        // if (isGameOver)
        //     return;

        // // Update the elapsed time
        // elapsedTime += Time.deltaTime;

        // // Check if the time limit has been reached
        // if (elapsedTime >= timeLimit)
        // {
        //     EndGame(false); // User loses if time limit is exceeded
        //     return;
        // }

        // // Check if the user is below the table
        // if (playerTransform.position.y < sturdyTableTransform.position.y)
        // {
        //     EndGame(true); // User wins if below the table
        // }
    }

    // void EndGame(bool isWinner)
    // {
    //     isGameOver = true;

    //     if (isWinner)
    //     {
    //         Debug.Log("Congratulations! You win!");
    //         // Implement logic for winning the level
    //         levelTextManager.DisplayLevelComplete();
    //     }
    //     else
    //     {
    //         Debug.Log("Time's up! You lose!");
    //         // Implement logic for losing the level
    //     }
    // }

    private void CheckLevelComplete() {
        // Check if the level is complete
        if (BedroomSceneState.Level6Complete()) {
            levelTextManager.DisplayLevelComplete();
            bedroomEmergencies.StopEarthquake();
            // bedroomEmergencies.ExtinguishElectricalFire();
            // Click some button on the UI to increment to next level?
        }
    }

    private void CheckGameOver()
    {
        // Check if the game is over
        if (!gameOver && GlobalState.IsGameOver())
        {
            // levelObjectManager.ResetLevel();
            BedroomSceneState.ResetLevel6();
            gameOver = true; // Set game over flag
            gameOverTimer = 0f; // Reset timer
        }

        // If game over flag is set, wait for the delay before changing scene
        if (gameOver)
        {
            gameOverTimer += Time.deltaTime;
            if (gameOverTimer >= gameOverDelay)
            {
                // Load game over scene after the delay
                SceneManager.LoadScene("DeathIsOnlyTheBeginning");
            }
        }
    }



    /*
    Electrical Fire scene related
    */
}
