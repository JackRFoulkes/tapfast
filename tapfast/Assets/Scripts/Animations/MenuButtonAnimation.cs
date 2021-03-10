using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAnimation : MonoBehaviour
{

    [SerializeField]
    Animator settingsAnimator;

    bool HasSlid;

    public void ShowGameModes()
    {
        if (!HasSlid)
        {
            settingsAnimator.SetTrigger("Slide");
            HasSlid = true;
        }
        else
        {
            settingsAnimator.SetTrigger("Slide Up");
            HasSlid = false;
        }
    }
}