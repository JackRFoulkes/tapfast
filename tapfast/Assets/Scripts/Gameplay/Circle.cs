using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Awake is called before start 
    private void Awake()
    {
        // Give this circle a random start position
        gameObject.transform.position = Utils.RandomScreenPosition();
    }

    // When this object is clicked
    private void OnMouseDown()
    {
        // Make this object inactive we will count them later.
        gameObject.SetActive(false);
    }
}