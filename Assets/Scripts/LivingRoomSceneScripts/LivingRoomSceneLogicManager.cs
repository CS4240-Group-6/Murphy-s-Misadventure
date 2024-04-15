using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomSceneLogicManager : MonoBehaviour
{
    private LevelTextManager levelTextManager;
    private LivingRoomEmergencies livingRoomEmergencies;
    private bool gameOver = false;
    private float gameOverTimer = 0f;
    private float gameOverDelay = 3f; // 2 second delay before changing scene
    // Start is called before the first frame update
    void Start()
    {
        levelTextManager = GetComponent<LevelTextManager>();
        livingRoomEmergencies = GetComponent<LivingRoomEmergencies>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        CheckLevelComplete();
    }

    private void CheckGameOver() {
        // Check if the game is over
        if (!gameOver && GlobalState.IsGameOver())
        {
            // levelManager.ResetLevel();
            LivingRoomSceneState.ResetLevel1();
            LivingRoomSceneState.ResetLevel2();
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

    private void CheckLevelComplete() {
        // Check if the level is complete
        if (GlobalState.GetLevel() == 1 && LivingRoomSceneState.Level1Complete())
        {
            Debug.Log("level 1 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            livingRoomEmergencies.StopLightFuseScene();
            // GlobalState.IncrementLevel();
        }
        if (GlobalState.GetLevel() == 2 && LivingRoomSceneState.Level2Complete()) 
        {
            Debug.Log("level 2 complete");
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            livingRoomEmergencies.StopIntruderScene();
        }
    }
}
