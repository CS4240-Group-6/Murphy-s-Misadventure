using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 originalLocalPosition;
    public Vector3 grabOffset = new Vector3(0f, 0f, 2.0f); // Adjust this vector to set the desired grab position

    protected override void Awake()
    {
        base.Awake();
        // Set the movement type to VelocityTracking for smoother motion based on velocity
        movementType = MovementType.VelocityTracking;

        // Enable smoothing for position and rotation
        smoothPosition = true;
        smoothRotation = true;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Store the original position before any modifications
        originalLocalPosition = args.interactor.attachTransform.localPosition;
        // Apply the offset to move the object further from the face
        args.interactor.attachTransform.localPosition += grabOffset;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        // Reset the position to the original when the object is released
        args.interactor.attachTransform.localPosition = originalLocalPosition;
    }
}
