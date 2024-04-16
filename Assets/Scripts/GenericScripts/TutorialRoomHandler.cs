using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialRoomHandler : MonoBehaviour
{
    [SerializeField] private GameObject TooltipForIntroDoor;
    [SerializeField] private FuseBoxAnimation fuseBoxAnimation;

    // Intro scene
    public bool isHoverIntroDoor;
    public bool isHoverFuseBoxSwitch;

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

    public void hoverOnFuseBoxSwitch()
    {
        isHoverFuseBoxSwitch = true;
    }

    public void hoverOffFuseBoxSwitch()
    {
        isHoverFuseBoxSwitch = false;
    }

    public void ActivateFuseBoxSwitch()
    {
        fuseBoxAnimation.OnSwitchPress();
    }
}
