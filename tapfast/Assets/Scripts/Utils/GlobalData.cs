using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    // Game mode the user has selected and what that corresponds to
    public static int GameMode { get; set; }
    public enum GameModes
    {
        Classic,
        Infinite
    }
}