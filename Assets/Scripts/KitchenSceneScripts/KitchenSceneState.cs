using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KitchenSceneState
{
    private static bool gasStoveTurnedOff = false;
    private static bool panCovered = false;
    private static bool oilAddedToPan = false;
    private static bool sodaAddedToPan = false;
    private static bool waterAddedToPan = false;
    private static bool fireExtinguisherUsed = false;

    // SMALL FIRE - 2:50 TO 2:00
    public static void SetPanCovered(bool isCovered)
    {
        panCovered = isCovered;
    }

    public static bool IsPanCovered()
    {
        return panCovered;
    }

    public static void SetGasStoveTurnedOff(bool isTurnedOff)
    {
        gasStoveTurnedOff = isTurnedOff;
    }

    public static bool IsGasStoveTurnedOff()
    {
        return gasStoveTurnedOff;
    }

    // BIG FIRE - 2:00 TO 1:00
    public static void SetOilAddedToPan(bool isAdded)
    {
        oilAddedToPan = isAdded;
        Debug.Log("Oil added to pan");
    }

    public static bool IsOilAddedToPan()
    {
        return oilAddedToPan;
    }

    public static void SetSodaAddedToPan(bool isAdded)
    {
        sodaAddedToPan = isAdded;
    }

    public static bool IsSodaAddedToPan()
    {
        return sodaAddedToPan;
    }

    // EVEN BIGGER FIRE - 1:00 TO END OR IF WATER ADDED
    public static void SetFireExtinguisherUsed(bool isUsed)
    {
        fireExtinguisherUsed = isUsed;
    }

    public static bool IsFireExtinguisherUsed()
    {
        return fireExtinguisherUsed;
    }

    // MISTAKE ACTION
    public static void SetWaterAddedToPan(bool isAdded)
    {
        waterAddedToPan = isAdded;
    }

    public static bool IsWaterAddedToPan()
    {
        return waterAddedToPan;
    }

    public static bool Level3Complete()
    {
        // return gasStoveTurnedOff && oilAddedToPan;
        if (waterAddedToPan)
        {
            return gasStoveTurnedOff && fireExtinguisherUsed;
        }
        else if (LevelTextManager.timeRemaining > 120.0f)
        {
            return gasStoveTurnedOff && panCovered;
        }
        else if (LevelTextManager.timeRemaining > 60.0f)
        {
            return gasStoveTurnedOff && (oilAddedToPan || sodaAddedToPan);
        }
        else
        {
            return gasStoveTurnedOff && fireExtinguisherUsed;
        }
    }

    public static void ResetLevel3()
    {
        gasStoveTurnedOff = false;
        panCovered = false;
        oilAddedToPan = false;
        sodaAddedToPan = false;
        waterAddedToPan = false;
        fireExtinguisherUsed = false;
    }
}
