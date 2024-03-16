using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private List<ResetObject> resetObjects = new List<ResetObject>();
    void Start()
    {
        ResetObject[] foundObjects = GetComponentsInChildren<ResetObject>();
        resetObjects.AddRange(foundObjects);

        StartCoroutine(CheckGameOver());

        // Start the reset coroutine with a delay of 10 seconds
        // StartCoroutine(ResetLevelAfterDelay(10f));
    }

    // Coroutine to constantly check if game is over
    private IEnumerator CheckGameOver()
    {
        while (true)
        {
            // If the game is over, reset the level
            if (GlobalState.IsGameOver())
            {
                ResetLevel();

                // Wait for 1 second
                yield return new WaitForSeconds(1f);

                // Load game over scene
                SceneManager.LoadScene("DeathIsOnlyTheBeginning");
            }

            // Wait for the next frame
            yield return null;
        }
    }

    // Coroutine to reset the level after a delay
    private IEnumerator ResetLevelAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Reset the positions of all objects in the level
        ResetLevel();
    }

    public void ResetLevel()
    {
        foreach (ResetObject ro in resetObjects)
        {
            ro.ResetPosition();
        }
    }

}
