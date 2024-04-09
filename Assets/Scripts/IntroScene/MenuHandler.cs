using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("KitchenScene");
    }

    public void EndGame()
    {
        // Will only work when the game is built and the option is chosen
        Application.Quit();
    }

    public void EnterShowCaseRoom()
    {
        SceneManager.LoadScene("ShowcaseOfStuff");  
    }
}
