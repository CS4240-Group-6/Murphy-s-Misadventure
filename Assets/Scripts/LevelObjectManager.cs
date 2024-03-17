using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelObjectManager : MonoBehaviour
{
    private List<ResetObject> resetObjects = new List<ResetObject>();
    void Start()
    {
        ResetObject[] foundObjects = GetComponentsInChildren<ResetObject>();
        resetObjects.AddRange(foundObjects);
    }

    // Coroutine to reset the level after a delay
    // private IEnumerator ResetLevelAfterDelay(float delay)
    // {
    //     // Wait for the specified delay
    //     yield return new WaitForSeconds(delay);

    //     // Reset the positions of all objects in the level
    //     ResetLevel();
    // }

    public void ResetLevel()
    {
        foreach (ResetObject ro in resetObjects)
        {
            ro.ResetPosition();
        }
    }

}
