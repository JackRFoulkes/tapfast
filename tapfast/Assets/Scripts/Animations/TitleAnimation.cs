using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{

    [SerializeField]
    float WaitBetween = 0.15f;

    [SerializeField]
    float WaitEnd = 0.5f;

    List<Animator> animators;

    // Start is called before the first frame update
    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(WaitBetween);
            }

            yield return new WaitForSeconds(WaitEnd);
        }
    }
}