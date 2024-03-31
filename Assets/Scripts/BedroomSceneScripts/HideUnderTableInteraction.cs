using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnderTableInteraction : MonoBehaviour
{
    public GameObject sturdyTable;
    public GameObject flimsyTable;
    public Transform cameraOffset;
    public GameObject player;
    [SerializeField] BoxCollider sturdyTableAreaCollider;
    [SerializeField] BoxCollider flimsyTableAreaCollider;

    private Vector3 playerPrevPosition = new Vector3(0f, 5.2f, 0f);
    
    [Header("Tooltips")]
    [SerializeField] private GameObject tooltipForSturdyTable;
    [SerializeField] private GameObject tooltipForFlimsyTable;

    public void SetPlayerUnderSturdyTable() {
        if (tooltipForSturdyTable.activeSelf) {
            Debug.Log("playerPrevPos 1: " + playerPrevPosition);
            Vector3 crouchPosition = new Vector3(-8.5f, 1f, 1.4f);
            cameraOffset.position = crouchPosition;
            BedroomSceneState.SetUnderCorrectTable(true);
        }
        if (tooltipForFlimsyTable.activeSelf) {
            Vector3 crouchPosition = new Vector3(0.27f, 1f, 13.127f);
            cameraOffset.position = crouchPosition;
            BedroomSceneState.SetUnderCorrectTable(false);
        }
        // TODO: Set exit from under table to be somewhere else (like upon level complete or sth!!!)
        Invoke("ExitFromUnderTable", 5f);
    }  

    public void ExitFromUnderTable() {
        if (IsPlayerBelowTable(player, sturdyTable, sturdyTableAreaCollider) || IsPlayerBelowTable(player, flimsyTable, flimsyTableAreaCollider)) {
            cameraOffset.position = playerPrevPosition;
        } 
    }

    public void hoverOnSturdyTableForToolTip()
    {
        tooltipForSturdyTable.SetActive(true);
    }
    public void hoverOffSturdyTableForToolTip()
    {
        tooltipForSturdyTable.SetActive(false);
    }

    public void hoverOnFlimsyTableForToolTip()
    {
        tooltipForFlimsyTable.SetActive(true);
    }
    public void hoverOffFlimsyTableForToolTip()
    {
        tooltipForFlimsyTable.SetActive(false);
    }

    private bool IsPlayerBelowTable(GameObject player, GameObject table, BoxCollider boxCollider)
    {
        if (table == null)
            return false;

        // Check if the player is below the specified table based on their positions
        return player.transform.position.y < table.transform.position.y && (boxCollider.bounds.Contains(player.transform.position));
    }
}
