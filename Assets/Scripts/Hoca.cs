using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoca : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int requiredLevel;
    [SerializeField] private string parameterName;
    private bool animationCompleted = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        animator.SetBool(parameterName, false);
    }
    // Update is called once per frame
    void Update()
    {
        if (requiredLevel == LevelManager.instance.level && !animationCompleted)
        {
            animator.enabled = true;
            animator.SetBool(parameterName, true);
            animationCompleted = true;
        }
    }
}
