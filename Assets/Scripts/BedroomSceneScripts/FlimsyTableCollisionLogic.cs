using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlimsyTableCollisionLogic : MonoBehaviour
{
    [SerializeField] BoxCollider flimsyTableAreaCollider;
    [SerializeField] private GameObject player;
    public GameObject playerCameraOffset;

    public GameObject flimsyTable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CeilingChunk") && !BedroomEmergencies.isEarthquakeLevelOver)
        {
            Debug.Log("collide with ceiling!");
            // Check if the player is below the sturdyTable or any other table except the sturdyTable
            if (IsPlayerBelowTable(player, flimsyTable))
            {
                GlobalState.SetGameOver(true);
            }
        }
    }

    // This function checks if player is below the sturdy table and is also within the boundaries of the sturdy table
    private bool IsPlayerBelowTable(GameObject player, GameObject table)
    {
        float playerAfterOffset = player.transform.position.y - playerCameraOffset.transform.position.y;
        if (table == null)
            return false;

        // Check if the player is below the specified table based on their positions
        return playerAfterOffset < table.transform.position.y && (flimsyTableAreaCollider.bounds.Contains(player.transform.position));
    }

    private void EndGame(bool isWinner)
    {
        BedroomEmergencies.isEarthquakeLevelOver = true;
        if (isWinner)
        {
            Debug.Log("Congratulations! You win!");
        }
        else
        {
            Debug.Log("You lost! Try again.");
        }
    }
}
