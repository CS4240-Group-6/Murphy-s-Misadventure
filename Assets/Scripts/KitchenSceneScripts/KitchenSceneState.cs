using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KitchenSceneState
{
    private static bool gasStoveTurnedOff = false;
    private static bool oilAddedToPan = false;
    private static bool sodaAddedToPan = false;
    private static bool waterAddedToPan = false;

    public static void SetGasStoveTurnedOff(bool isTurnedOff)
    {
        gasStoveTurnedOff = isTurnedOff;
    }

    public static bool IsGasStoveTurnedOff()
    {
        return gasStoveTurnedOff;
    }

    public static void SetOilAddedToPan(bool isAdded)
    {
        oilAddedToPan = isAdded;
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
        return gasStoveTurnedOff;
    }

    public static void ResetLevel3()
    {
        gasStoveTurnedOff = false;
        oilAddedToPan = false;
        sodaAddedToPan = false;
        waterAddedToPan = false;
    }
}
