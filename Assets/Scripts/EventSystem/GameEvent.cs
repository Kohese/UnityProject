using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    public const string INCREASE_SCORE = "INCREASE_SCORE";    // Used for scoring enemies hit

    public const string UPDATE_HEALTH = "UPDATE_HEALTH";    // player health script updates hud health display

    public const string PAUSE_GAME = "PAUSE_GAME";  // generic command to stop/resume game; recievers use their own implementation
        // TRUE = game is paused
        // FALSE = game is running

    public const string RESULT_SCREEN = "RESULT_SCREEN";    
}
