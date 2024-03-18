using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenInteractions : MonoBehaviour
{
    public GameObject InteractableObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
        PUBLIC FUNCTIONS FOR ROTATING STOVE KNOBS
        
        Left1 - third from the left
        Left2 - last from the left

        Right1 - second from the left
        Right2 - first from the left

        (dont ask me why theyre named this way...its from the asset)
    */
    public void RotateStoveKnobLeft1()
    {
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobLeft1");
            if (StoveKnobLeft1 != null)
            {
                float speed = 0.1f;
                Quaternion currentRot = StoveKnobLeft1.rotation;

                Vector3 newRot = new Vector3(0f, 0f, 90f);
                Quaternion targetRot = currentRot * Quaternion.Euler(newRot);
                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, speed);
            }
            else Debug.Log("no child with stove knob left 1 found");
        }
        else Debug.Log("no child with stove found");
    }

    public void RotateStoveKnobLeft2()
    {
        
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobLeft2");
            if (StoveKnobLeft1 != null)
            {
                float speed = 0.1f;
                Quaternion currentRot = StoveKnobLeft1.rotation;

                Vector3 newRot = new Vector3(0f, 0f, 90f);
                Debug.Log("IT WORKS");
                Debug.Log("New Rotation: " + newRot);
                Quaternion targetRot = currentRot * Quaternion.Euler(newRot);
                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, speed);
                Debug.Log(StoveKnobLeft1.rotation);
                KitchenSceneState.SetGasStoveTurnedOff(true);
            }
            else Debug.Log("no child with stove knob left 2 found");
        }
        else Debug.Log("no child with stove found");
    }

    public void RotateStoveKnobRight1()
    {
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobRight1");
            if (StoveKnobLeft1 != null)
            {
                float speed = 0.1f;
                Quaternion currentRot = StoveKnobLeft1.rotation;

                Vector3 newRot = new Vector3(0f, 0f, 90f);
                Quaternion targetRot = currentRot * Quaternion.Euler(newRot);
                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, speed);
            }
            else Debug.Log("no child with stove knob right 1 found");
        }
        else Debug.Log("no child with stove found");
    }

    public void RotateStoveKnobRight2()
    {
        Debug.Log("Reaches function");
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobRight2");
            if (StoveKnobLeft1 != null)
            {
                float speed = 0.1f;
                Quaternion currentRot = StoveKnobLeft1.rotation;

                Vector3 newRot = new Vector3(0f, 0f, 90f);
                Quaternion targetRot = currentRot * Quaternion.Euler(newRot);
                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, speed);
            }
            else Debug.Log("no child with stove knob right 2 found");
        }
        else Debug.Log("no child with stove found");
    }

}
