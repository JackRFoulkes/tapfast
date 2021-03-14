using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // Returns a Vector 3 within the boundaries of the main camera with a default z of 0
    public static Vector3 RandomScreenPosition()
    {
        float spawnY = Random.Range(
            Camera.main.ScreenToWorldPoint(new Vector2(0, 150)).y, 
            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - 350)).y
            );

        float spawnX = Random.Range(
            Camera.main.ScreenToWorldPoint(new Vector2(150, 0)).x, 
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 150, 0)).x
            );

        Vector3 randomPos = new Vector3(spawnX, spawnY, 0);
        randomPos.z = 0;

        return randomPos;
    }
}