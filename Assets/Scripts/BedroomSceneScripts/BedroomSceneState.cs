using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSceneState : MonoBehaviour
{
    private static bool playerUnderCorrectTable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
