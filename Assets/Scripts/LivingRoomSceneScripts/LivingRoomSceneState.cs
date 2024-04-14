using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class LivingRoomSceneState
{
    /** Level 1 state */
    private static bool isExtensionCordPulled = false;
    private static bool isCircuitBreakerOn = false;

    /** Level 2 state */
    private static bool isDoorLocked = false;

    public static void SetExtensionCordPulled()
    {
        isExtensionCordPulled = true;
    }

    /** Level 1 state functions */
    public static bool IsExtensionCordPulled()
    {
        return isExtensionCordPulled;
    }

    public static void SetCircuitBreakerOn()
    {
        isCircuitBreakerOn = true;
    }

    public static bool IsCircuitBreakerOn()
    {
        return isCircuitBreakerOn;
    }

    public static bool Level1Complete()
    {
        return isExtensionCordPulled && isCircuitBreakerOn;
        // return PlayerPrefs.GetInt("CircuitBreakerState") == 1;
    }
    
    public static void ResetLevel1()
    {
        // Reset the state of the circuit breaker
        isExtensionCordPulled = false;
        isCircuitBreakerOn = false;
    }

    /** Level 2 state functions */
    public static void SetDoorLocked()
    {
        isDoorLocked = true;
    }
    
    public static bool Level2Complete()
    {
        return isDoorLocked;
    }

    public static void ResetLevel2()
    {
        // Reset the state of the main door
        isDoorLocked = false;
    }
}
