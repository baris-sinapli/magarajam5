using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string parameterName;
    [SerializeField] private int requriedLevel;
    private bool triggerStay = false;
    private bool animationCompleted = false;
    void Update()
    {
        
        if (triggerStay && requriedLevel == LevelManager.instance.level && !animationCompleted)
        {
            animator.gameObject.SetActive(true);
            animator.SetBool(parameterName, true);
            animationCompleted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerStay = false;
        }
    }
}
