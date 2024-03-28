using UnityEngine;
using TMPro;

public class LevelCanvasController : MonoBehaviour
{
    public Canvas levelCanvas;
    public TMP_Text headerText;
    public TMP_Text descriptionText;
    public GameObject dimBackground; // An image or panel with a semi-transparent black color

    private void Start()
    {
        // Hide the canvas initially
        levelCanvas.gameObject.SetActive(false);
        dimBackground.SetActive(false);
    }

    public void ShowDeathMessage()
    {
        headerText.text = "You are dead.";
        descriptionText.text = "Mm... maybe try something else?";
        ShowCanvas();
        // Handle additional game pause logic if necessary
    }

    public void ShowLevelCompleteMessage(string levelSummary)
    {
        headerText.text = "Level complete!";
        descriptionText.text = $"{levelSummary}";
        ShowCanvas();
        // Handle additional level completion logic here
    }

    public void ShowWelcomeMessage(int levelNumber, string levelDescription)
    {
        headerText.text = $"Welcome to Level {levelNumber}!";
        descriptionText.text = $"{levelDescription}";
        ShowCanvas();
        // Maybe start a coroutine to hide the canvas after a few seconds
    }

    public void ShowCanvas()
    {
        // Show the canvas and the dim background
        levelCanvas.gameObject.SetActive(true);
        dimBackground.SetActive(true);
    }
    
    // Call this method to hide the canvas
    public void HideCanvas()
    {
        levelCanvas.gameObject.SetActive(false);
        dimBackground.SetActive(false);
        // Handle resuming game logic if necessary
    }
}
