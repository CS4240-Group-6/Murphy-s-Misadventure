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
    public static bool Level2Complete()
    {
        return true;
        // if (waterAddedToOven)
        // {
        //     return ovenTurnedOff && fireExtinguisherUsed;
        // }
        // else if (LevelTextManager.timeRemaining > 120.0f)
        // {
        //     return ovenTurnedOff;
        // }
        // else
        // {
        //     return ovenTurnedOff && fireExtinguisherUsed;
        // }
    }

    public static void ResetLevel2()
    {
        // Reset the state of the main door
        // PlayerPrefs.SetInt("MainDoorState", 0);
    }
}
