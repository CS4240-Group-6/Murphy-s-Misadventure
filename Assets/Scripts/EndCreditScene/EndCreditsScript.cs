using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReturnToMainMenu", 30.0f);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Introduction");
    }
}
