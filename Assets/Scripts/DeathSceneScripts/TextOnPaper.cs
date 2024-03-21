
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshPro textMesh;
    public string[] lines; // Array of lines to display
    public float revealSpeed = 0.05f; // Speed of revealing each character
    public float delayBetweenLines = 1f; // Delay between revealing each line
    public TextMeshPro textToDisplay;

    private int currentLineIndex = 0;

    void Start()
    {
        lines = textToDisplay.text.Split('\n');
        
    }

    public void DisplayTextOnPaper() {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        string fullText = "";
        foreach (string line in lines)
        {
            fullText += line + "\n"; // Concatenate each line
        }

        for (int i = 0; i <= fullText.Length; i++)
        {
            textMesh.text = fullText.Substring(0, i); // Display concatenated text
            yield return new WaitForSeconds(revealSpeed);
        }
    }
}
