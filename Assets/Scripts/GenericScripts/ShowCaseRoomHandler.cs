using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCaseRoomHandler : MonoBehaviour
{
    [SerializeField] private GameObject TooltipForIntroDoor;

    // Intro scene
    public bool isHoverIntroDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hoverOnDoorForToolTip()
    {
        isHoverIntroDoor = true;
        TooltipForIntroDoor.SetActive(true);
    }

    public void hoverOffDoorForToolTip()
    {
        isHoverIntroDoor = false;
        TooltipForIntroDoor.SetActive(false);
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Introduction");
    }
}
