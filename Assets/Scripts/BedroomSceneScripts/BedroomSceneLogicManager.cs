using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomSceneLogicManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    public Transform sturdyTableTransform;
    public Transform playerTransform;
    private LevelTextManager levelTextManager;
    private BedroomEmergencies bedroomEmergencies;
    public float timeLimit = 60f;
    private float elapsedTime = 0f;
    private bool gameOver = false;
    private float gameOverTimer = 0f;
    private float gameOverDelay = 8f; // 1 second delay before changing scene
    private bool levelCompleted = false;

    void Start()
    {
        levelTextManager = GetComponent<LevelTextManager>();
        bedroomEmergencies = GetComponent<BedroomEmergencies>();
    }

    void Update()
    {
        CheckGameOver();
        CheckLevelComplete();
    }

    private void CheckGameOver()
    {
        // Check if the game is over
        if (!gameOver && GlobalState.IsGameOver())
        {
            levelManager.ResetLevel();
            BedroomSceneState.ResetLevel5();
            BedroomSceneState.ResetLevel6();
            gameOver = true; // Set game over flag
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.SetTimeRemaining(180);
            levelTextManager.DisplayLevelTexts();
            gameOverTimer = 0f; // Reset timer
        }

        // If game over flag is set, wait for the delay before changing scene
        if (gameOver)
        {
            gameOverTimer += Time.deltaTime;
            if (gameOverTimer >= gameOverDelay)
            {
                gameOver = false; // Reset game over flag
                // Load game over scene after the delay
                SceneManager.LoadScene("DeathIsOnlyTheBeginning");
            }
        }
    }

    private void CheckLevelComplete() 
    {
        // Check if the level is complete
        if (BedroomSceneState.Level5Complete() && GlobalState.GetLevel() == 5) 
        {
            Debug.Log("level 5 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            bedroomEmergencies.SelectFuseBox();
        }
        if (BedroomSceneState.Level6Complete() && GlobalState.GetLevel() == 6) 
        {
            Debug.Log("level 6 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            bedroomEmergencies.StopEarthquake();
        }
    }
}
