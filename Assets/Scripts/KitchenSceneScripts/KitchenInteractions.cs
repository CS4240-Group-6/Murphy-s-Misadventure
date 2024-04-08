using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KitchenInteractions : MonoBehaviour
{
    [SerializeField] private GameObject Stove;

    [Header("Tooltips")]
    [SerializeField] private GameObject TooltipForKnobLeft2;
    [SerializeField] private GameObject TooltipForKnobLeft1;

    [SerializeField] private GameObject TooltipForKnobRight2;    
    [SerializeField] private GameObject TooltipForKnobRight1;
    [SerializeField] private GameObject TooltipForOvenDoor;
    [SerializeField] private GameObject TooltipForOvenSwitch;
    [SerializeField] private GameObject TooltipForTray;

    [SerializeField] private GameObject TooltipForOil;
    [SerializeField] private GameObject TooltipForBakingSoda;

    [SerializeField] private GameObject TooltipForWaterBottle;
    
    private static float STOVE_ON_ANGLE = 90f;
    private static float STOVE_OFF_ANGLE = 0f;

    private static float OVEN_OPEN_ANGLE = 90f;
    private static float OVEN_CLOSED_ANGLE = 0f;

    private static float SPEED = 5.0f;

    /**
        STATES OF THE KNOBS
    */
    public bool isHoverLeft1;
    public bool isHoverLeft2;
    public bool isHoverRight1;
    public bool isHoverRight2;

    private static float StoveKnobLeft1_state;
    private static float StoveKnobLeft2_state;
    private static float StoveKnobRight1_state;
    private static float StoveKnobRight2_state;

    private bool canRotateLeft1;
    private bool canRotateLeft2;
    private bool canRotateRight1;
    private bool canRotateRight2;

    /**
        STATES OF OVEN
    */
    public bool isHoverOvenSwitch;

    public static bool isOvenOn;


    /**
        STATES OF THE OVEN DOOR
    */
    public bool isHoverOvenDoor;

    private static float OvenDoor_state;

    private bool canRotateDoor;

    // Start is called before the first frame update
    void Start()
    {
        // HOVERS
        isHoverLeft1 = false;
        isHoverLeft2 = false;
        isHoverRight1 = false;
        isHoverRight2 = false;

        isHoverOvenDoor = false;

        isHoverOvenSwitch = false;

        // CAN START ACTION
        canRotateLeft1 = false;
        canRotateLeft2 = false;
        canRotateRight1 = false;
        canRotateRight2 = false;

        canRotateDoor = false;

        // STATES
        StoveKnobLeft1_state = STOVE_OFF_ANGLE;
        StoveKnobLeft2_state = STOVE_ON_ANGLE;
        StoveKnobRight1_state = STOVE_OFF_ANGLE;
        StoveKnobRight2_state = STOVE_OFF_ANGLE;
        OvenDoor_state = OVEN_CLOSED_ANGLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotateLeft1)
        {
            rotateStoveKnobLeft1();
        }

        if (canRotateLeft2)
        {
            rotateStoveKnobLeft2();
        }

        if (canRotateRight1)
        {
            rotateStoveKnobRight1();
        }

        if (canRotateRight2)
        {
            rotateStoveKnobRight2();
        }

        if (canRotateDoor)
        {
            openOvenDoor();
        }
    }


    /**
        PUBLIC FUNCTIONS FOR ROTATING STOVE KNOBS
        
        Left1 - third from the left
        Left2 - last from the left

        Right1 - second from the left
        Right2 - first from the left

        (dont ask me why theyre named this way...its from the asset)
    */
    public void IsHoverLeft1()
    {
        isHoverLeft1 = true;
    }

    public void IsExitHoverLeft1()
    {
        isHoverLeft1 = false;
    }


    public void IsHoverLeft2()
    {
        isHoverLeft2 = true;
    }

    public void IsExitHoverLeft2()
    {
        isHoverLeft2 = false;
    }


    public void IsHoverRight1()
    {
        isHoverRight1 = true;
    }

    public void IsExitHoverRight1()
    {
        isHoverRight1 = false;
    }


    public void IsHoverRight2()
    {
        isHoverRight2 = true;
    }

    public void IsExitHoverRight2()
    {
        isHoverRight2 = false;
    }


    public void RotateStoveKnobLeft1() 
    {
        if (StoveKnobLeft1_state == STOVE_ON_ANGLE)
        {
            StoveKnobLeft1_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobLeft1_state = STOVE_ON_ANGLE;
        }

        
        if (isHoverLeft1)
        {
            canRotateLeft1 = true;
        }
        else
        {
            canRotateLeft1 = false;
        }
        
    }

    public void RotateStoveKnobLeft2() 
    {
        if (StoveKnobLeft2_state == STOVE_ON_ANGLE)
        {
            StoveKnobLeft2_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobLeft2_state = STOVE_ON_ANGLE;
        }

        if (isHoverLeft2)
        {
            canRotateLeft2 = true;
        }
        else
        {
            canRotateLeft2 = false;
        }
    }

    public void RotateStoveKnobRight1()
    {
        if (StoveKnobRight1_state == STOVE_ON_ANGLE)
        {
            StoveKnobRight1_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobRight1_state = STOVE_ON_ANGLE;
        }

        if (isHoverRight1)
        {
            canRotateRight1 = true;
        }
        else
        {
            canRotateRight1 = false;
        }
    }

    public void RotateStoveKnobRight2()
    {
        if (StoveKnobRight2_state == STOVE_ON_ANGLE)
        {
            StoveKnobRight2_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobRight2_state = STOVE_ON_ANGLE;
        }

        if (isHoverRight2)
        {
            canRotateRight2 = true;
        }
        else
        {
            canRotateRight2 = false;
        }
    }


    /**
        PRIVATE COROUTINES TO MAKE THE ROTATION SMOOTH
    */
    private void rotateStoveKnobLeft1()
    {
        Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobLeft1");
        if (StoveKnobLeft1 != null)
        {
            Quaternion currentRot = StoveKnobLeft1.rotation;
            Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobLeft1_state));

            StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

            if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
            {
                canRotateLeft1 = false;
            }

            StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);
           }
        else Debug.Log("no child with stove knob left 1 found");
    }

    private void rotateStoveKnobLeft2()
    {
        Transform StoveKnobLeft2 = Stove.transform.Find("Stove-KnobLeft2");
        if (StoveKnobLeft2 != null)
        {
            Quaternion currentRot = StoveKnobLeft2.rotation;
            Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobLeft2_state));

            StoveKnobLeft2.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

            if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
            {
                if (currentRot.eulerAngles == new Vector3(0, 0, STOVE_ON_ANGLE))
                {
                    KitchenSceneState.SetGasStoveTurnedOff(true);
                }
                canRotateLeft2 = false;
            }

        }
        else Debug.Log("no child with stove knob left 2 found");
    }

    private void rotateStoveKnobRight1()
    {
        Transform StoveKnobRight1 = Stove.transform.Find("Stove-KnobRight1");
        if (StoveKnobRight1 != null)
        {
            Quaternion currentRot = StoveKnobRight1.rotation;
            Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobRight1_state));

            StoveKnobRight1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

            if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
            {
                canRotateRight1 = false;
            }
        }
        else Debug.Log("no child with stove knob right 1 found");
    }

    private void rotateStoveKnobRight2()
    {
        Transform StoveKnobRight2 = Stove.transform.Find("Stove-KnobRight2");
        if (StoveKnobRight2 != null)
        {
            Quaternion currentRot = StoveKnobRight2.rotation;
            Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobRight2_state));

            StoveKnobRight2.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

            if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
            {
                canRotateRight2 = false;
            }
        }
        else Debug.Log("no child with stove knob right 2 found");
    }

    public void hoverOnKnobLeft1ForToolTip()
    {
        TooltipForKnobLeft1.SetActive(true);
    }

    public void hoverOffKnobLeft1ForToolTip()
    {
        TooltipForKnobLeft1.SetActive(false);
    }

    public void hoverOnKnobLeft2ForToolTip()
    {
        TooltipForKnobLeft2.SetActive(true);
    }

    public void hoverOffKnobLeft2ForToolTip()
    {
        TooltipForKnobLeft2.SetActive(false);
    }

    public void hoverOnKnobRight2ForToolTip()
    {
        TooltipForKnobRight2.SetActive(true);
    }

    public void hoverOffKnobRight2ForToolTip()
    {
        TooltipForKnobRight2.SetActive(false);
    }

    public void hoverOnKnobRight1ForToolTip()
    {
        TooltipForKnobRight1.SetActive(true);
    }

    public void hoverOffKnobRight1ForToolTip()
    {
        TooltipForKnobRight1.SetActive(false);
    }

    public void hoverOnOvenDoorForToolTip()
    {
        TooltipForOvenDoor.SetActive(true);
    }

    public void hoverOffOvenDoorForToolTip()
    {
        TooltipForOvenDoor.SetActive(false);
    }

    public void hoverOnOvenSwitchForToolTip()
    {
        TooltipForOvenSwitch.SetActive(true);
    }

    public void hoverOffOvenSwitchForToolTip()
    {
        TooltipForOvenSwitch.SetActive(false);
    }

    public void hoverOnTrayForToolTip()
    {
        TooltipForTray.SetActive(true);
    }

    public void hoverOffTrayForToolTip()
    {
        TooltipForTray.SetActive(false);
    }

    public void hoverOnOilForToolTip()
    {
        TooltipForOil.SetActive(true);
    }

    public void hoverOffOilForToolTip()
    {
        TooltipForOil.SetActive(false);
    }

    public void hoverOnBakingSodaForToolTip()
    {
        TooltipForBakingSoda.SetActive(true);
    }

    public void hoverOffBakingSodaForToolTip()
    {
        TooltipForBakingSoda.SetActive(false);
    }

    public void hoverOnWaterBottleForToolTip()
    {
        TooltipForWaterBottle.SetActive(true);
    }

    public void hoverOffWaterBottleForToolTip()
    {
        TooltipForWaterBottle.SetActive(false);
    }

    /**
        PUBLIC FUNCTION FOR TURNING OVEN OFF/ON
    */
    public void IsHoverOvenSwitch()
    {
        isHoverOvenSwitch = true;
    }

    public void IsExitHoverOvenSwitch()
    {
        isHoverOvenSwitch = false;
    }

    public void ToggleOven()
    {
        if (isHoverOvenSwitch)
        {
            if (isOvenOn)
            {
                GameObject OvenSwitch = Stove.transform.Find("Stove-OvenSwitch").gameObject;
                if (OvenSwitch != null)
                {
                    var OvenSwitchRenderer = OvenSwitch.GetComponent<Renderer>();

                    OvenSwitchRenderer.material.SetColor("_Color", Color.red);
                    isOvenOn = false;
                }
                else Debug.Log("no child with oven switch found");
            } 
            else
            {
                GameObject OvenSwitch = Stove.transform.Find("Stove-OvenSwitch").gameObject;
                if (OvenSwitch != null)
                {
                    var OvenSwitchRenderer = OvenSwitch.GetComponent<Renderer>();

                    OvenSwitchRenderer.material.SetColor("_Color", Color.green);
                    isOvenOn = true;
                }
                else Debug.Log("no child with oven switch found");
            }
        }
    }

    /**
        PUBLIC FUNCTIONS FOR OPENING OVEN DOOR
    */
    public void IsHoverOvenDoor()
    {
        isHoverOvenDoor = true;
    }

    public void IsExitHoverOvenDoor()
    {
        isHoverOvenDoor = false;
    }

    public void OpenOvenDoor()
    {
        if (OvenDoor_state == OVEN_CLOSED_ANGLE)
        {
            OvenDoor_state = OVEN_OPEN_ANGLE;
        } 
        else
        {
            OvenDoor_state = OVEN_CLOSED_ANGLE;
        }

        if (isHoverOvenDoor)
        {
            canRotateDoor = true;
        }
    }

    /**
        PRIVATE COROUTINES TO MAKE THE ROTATION SMOOTH
    */
    private void openOvenDoor()
    {
        Transform OvenDoor = Stove.transform.Find("Stove-FrontDoor");
        if (OvenDoor != null)
        {
            Quaternion currentRot = OvenDoor.rotation;
            Quaternion targetRot = Quaternion.Euler(new Vector3(OvenDoor_state, 0, 0));

            OvenDoor.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);
            if (currentRot.eulerAngles.x == targetRot.eulerAngles.x)
            {
                canRotateDoor = false;
            }
        }
        else Debug.Log("no child with stove front door found");
    }

}
