using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diyalog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private string pressText;
    [SerializeField] private string[] dialog;
    [SerializeField] private Rigidbody2D rb;

    private bool triggerStay = false;
    private bool isDialogeStarted = false;
    private bool isDialogFinished = false;

    private int dialogIndex;


    private void Update()
    {
        if (triggerStay && isDialogeStarted && Input.GetKeyDown(KeyCode.Space))
        {
            if(dialogIndex < dialog.Length)
            {
                canvasText.text = dialog[dialogIndex];
                dialogIndex++;
            }
            if(dialogIndex == dialog.Length)
            {
                isDialogFinished = true;
            }
            if (isDialogFinished)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        if (triggerStay && !isDialogeStarted && Input.GetKeyDown(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            dialogIndex = 0;
            canvasText.text = dialog[dialogIndex];
            dialogIndex++;
            isDialogeStarted = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggerStay = true;
            canvasText.text = pressText;
            canvasText.gameObject.SetActive(true);

            rb = other.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            triggerStay = false;
        }
        dialogIndex = 0;

        isDialogeStarted = false;
        isDialogFinished = false;
        canvasText.text = "";
        canvasText.gameObject.SetActive(false);
    }
}
    
