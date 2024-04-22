using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    private static int level = 6;
    private static bool isGameOver = false;
    
    private static bool isStartLevel = true;

    public static void SetLevel(int newLevel)
    {
        level = newLevel;
    }

    public static void IncrementLevel()
    {
        level++;
    }

    public static int GetLevel()
    {
        return level;
    }

    public static void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }

    public static bool IsGameOver()
    {
        return isGameOver;
    }
     
    public static void SetStartLevel(bool startLevel)
    {
        isStartLevel = startLevel;
    }

    public static bool IsStartLevel()
    {
        return isStartLevel;
    }
}
