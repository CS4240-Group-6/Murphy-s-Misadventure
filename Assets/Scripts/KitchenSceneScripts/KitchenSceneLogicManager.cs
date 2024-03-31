using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenSceneLogicManager : MonoBehaviour
{
    private LevelTextManager levelTextManager;
    private KitchenEmergencies kitchenEmergencies;  
    private bool gameOver = false;
    private float gameOverTimer = 0f;
    private float gameOverDelay = 3f; // 2 second delay before changing scene


    // Start is called before the first frame update
    void Start()
    {
        // Assuming you have references to other managers/components
        levelTextManager = GetComponent<LevelTextManager>();
        kitchenEmergencies = GetComponent<KitchenEmergencies>();
    }

    // Update is called once per frame
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
            // levelObjectManager.ResetLevel();
            KitchenSceneState.ResetLevel3();
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

    private void CheckLevelComplete()
    {
        // Check if the level is complete
        if (KitchenSceneState.Level3Complete())
        {
            GlobalState.SetStartLevel(false); // Reset start level flag
            levelTextManager.DisplayLevelTexts();
            kitchenEmergencies.ExtinguishOilFire();
        }
    }
}
