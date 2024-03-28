using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShieldAnimation : MonoBehaviour
{
    public XRBaseInteractor shieldInteractor;
    public XRBaseInteractor leverInteractor;
    private Animator shieldAnimator;
    private bool isShieldOpen = false;
    private bool isLeverUp = true;
    private bool isGrabbingLever = false;
    private bool isGrabbingShield = false; 

    void Start()
    {
        shieldAnimator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        shieldInteractor.selectEntered.AddListener(OnShieldGrabbed);
        shieldInteractor.selectExited.AddListener(OnShieldReleased);
        leverInteractor.selectEntered.AddListener(OnLeverGrabbed);
        leverInteractor.selectExited.AddListener(OnLeverReleased); 
    }

    void OnDisable()
    {
        shieldInteractor.selectEntered.RemoveListener(OnShieldGrabbed);
        shieldInteractor.selectExited.RemoveListener(OnShieldReleased); 
        leverInteractor.selectEntered.RemoveListener(OnLeverGrabbed);
        leverInteractor.selectExited.RemoveListener(OnLeverReleased); 
    }

    private void OnShieldGrabbed(SelectEnterEventArgs args)
    {
        // Check if the shield is already being grabbed
        if (!isGrabbingShield)
        {
            isGrabbingShield = true; 
            ToggleShield();
        }
    }

    private void OnShieldReleased(SelectExitEventArgs args) 
    {
        // Reset the flag when the shield is released
        isGrabbingShield = false;
    }

    private void ToggleShield()
    {
        // Toggle shield open/close with animation
        if (isShieldOpen)
        {
            shieldAnimator.Play("CloseShield");
        }
        else
        {
            shieldAnimator.Play("OpenShield");
        }
        isShieldOpen = !isShieldOpen;
    }

    private void OnLeverGrabbed(SelectEnterEventArgs args)
    {
        // Only allow lever interaction if the shield is open and the lever is not being grabbed
        if (isShieldOpen && !isGrabbingLever)
        {
            isGrabbingLever = true; // Update the flag when the lever is grabbed
            ToggleLever();
        }
    }

    private void OnLeverReleased(SelectExitEventArgs args)
    {
        // Reset the flag when the lever is released
        isGrabbingLever = false;
    }

    private void ToggleLever()
    {
        // Toggle the lever up/down with animation
        if (isLeverUp)
        {
            shieldAnimator.Play("PullDownLever");
        }
        else
        {
            shieldAnimator.Play("PullUpLever");
        }
        isLeverUp = !isLeverUp;
    }
}

