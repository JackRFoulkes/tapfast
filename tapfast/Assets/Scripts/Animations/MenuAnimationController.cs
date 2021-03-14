using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{

    #region Play Button Actions

    [SerializeField]
    Animator mainMenuAnimator;

    public void Play()
    {
        // Triggers when clicking the play button on the home screen
        mainMenuAnimator.SetTrigger("SlideIn");
    }

    public void PlayBack()
    {
        // Trigger when clicking back after clicking play
        mainMenuAnimator.SetTrigger("SlideOut");
    }
    #endregion
}