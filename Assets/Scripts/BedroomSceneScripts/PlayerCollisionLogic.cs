using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionLogic : MonoBehaviour
{
    public GameObject flimsyTable;
    private bool isGameOver = false;
    [SerializeField] private GameObject player;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CeilingChunk") && !isGameOver)
        {
            Debug.Log("collide with ceiling!");
            // Check if the player is below the sturdyTable or any other table except the sturdyTable
            if (BedroomSceneState.IsPlayerUnderCorrectTable())
            {
                // Player is below the sturdyTable, safe from falling ceiling chunks
                // Optionally, you can implement UI feedback or other actions here
            }
            else if (IsPlayerBelowTable(player, flimsyTable))
            {
                // Player is below another table (e.g., flimsyTable), which collapses
                // EndGame(false); // Player loses
                GlobalState.SetGameOver(true);
            }
            else
            {
                EndGame(false); // Player loses
                GlobalState.SetGameOver(true);
            }
        }
    }

    private bool IsPlayerBelowTable(GameObject player, GameObject table)
    {
        if (table == null)
            return false;

        // Check if the player is below the specified table based on their positions
        return player.transform.position.y < table.transform.position.y;
    }

    // Method to end the game with the specified outcome
    private void EndGame(bool isWinner)
    {
        isGameOver = true;
        BedroomEmergencies.isEarthquakeLevelOver = true;
        if (isWinner)
        {
            Debug.Log("Congratulations! You win!");
            // Implement logic for winning the game
        }
        else
        {
            Debug.Log("You lost! Try again.");
            // Implement logic for losing the game
        }
    }
}
