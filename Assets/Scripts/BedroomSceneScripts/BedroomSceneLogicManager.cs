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
    }

    private void CheckLevelComplete() {
        // Check if the level is complete
        if (BedroomSceneState.Level6Complete()) 
        {
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
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
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
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
