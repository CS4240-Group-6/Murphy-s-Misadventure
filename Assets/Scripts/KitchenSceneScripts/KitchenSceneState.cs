using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KitchenSceneState
{
    private static bool gasStoveTurnedOff = false;
    private static bool oilAddedToPan = false;

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

    public static bool Level3Complete()
    {
        // return gasStoveTurnedOff && oilAddedToPan;
        return gasStoveTurnedOff;
    }

    public static void ResetLevel3()
    {
        gasStoveTurnedOff = false;
        oilAddedToPan = false;
    }
}
