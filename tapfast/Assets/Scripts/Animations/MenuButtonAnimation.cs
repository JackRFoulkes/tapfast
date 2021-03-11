using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonAnimation : MonoBehaviour
{

    [SerializeField]
    Animator settingsAnimator;

    [SerializeField]
    GameObject gameModes;
    Animator gameModeAnimator;
    Button[] gameModeButtons;

    bool HasSlid;

    public void Start()
    {
        gameModes.SetActive(false);
        gameModeAnimator = gameModes.GetComponent<Animator>();
        gameModeButtons = gameModes.GetComponentsInChildren<Button>();
    }

    public void ShowGameModes()
    {
        if (!HasSlid)
        {
            // Slide settings button
            settingsAnimator.SetTrigger("Slide");

            // Show game modes
            gameModes.SetActive(true);
            gameModeAnimator.SetTrigger("FadeIn");
        }
    }
}