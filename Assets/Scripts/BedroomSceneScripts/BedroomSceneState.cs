using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BedroomSceneState
{
    private static bool playerUnderCorrectTable = false;
    private static bool isCircuitBreakerOff = false;
    private static bool isYellowFireExtinguished = false;
    private static bool isBlueFireExtinguished = false;
    private static bool isGreenFireExtinguished = false;

    /*
    Earthquake scene related. And a frog?!
            _    _
           (o)--(o)        ____________
          /.______.\      /hello there.\
          \________/     -\____________/
         ./        \.    
        ( .        , )
         \ \_\\//_/ /
          ~~  ~~  ~~
    */
    public static void SetUnderCorrectTable(bool isUnderSturdyTable) {
        playerUnderCorrectTable = isUnderSturdyTable;
    }

    public static bool IsPlayerUnderCorrectTable() {
        return playerUnderCorrectTable;
    }

    /*
    Electrical Fire scene related
    */
    public static void SetExtinguishBlueFlames(bool isExtinguished) {
        isBlueFireExtinguished = isExtinguished;
    }

    public static void SetExtinguishGreenFlames(bool isExtinguished) {
        isGreenFireExtinguished = isExtinguished;
    }

    public static void SetExtinguishYellowFlames(bool isExtinguished) {
        isYellowFireExtinguished = isExtinguished;
    }

    public static void SetCircuitBreakerOff(bool isOff) {
        isCircuitBreakerOff = isOff;
    }

    public static bool Level5Complete() {
        // player has extinguished the fire
        return isBlueFireExtinguished && isGreenFireExtinguished && isYellowFireExtinguished && isCircuitBreakerOff;
    }

    public static void ResetLevel5() {
        isBlueFireExtinguished = false;
        isGreenFireExtinguished = false;
        isYellowFireExtinguished = false;
        isCircuitBreakerOff = false;
    }

    /*
    Level related
    */
    public static bool Level6Complete() {
        // player is under correct tabel for x number of minutes
        return playerUnderCorrectTable;
    }

    public static void ResetLevel6() {
        playerUnderCorrectTable = false;
    }
}
