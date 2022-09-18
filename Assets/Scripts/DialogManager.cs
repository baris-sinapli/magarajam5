using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI canvasText;

    [Header("Dialog #1 Options")]
    [SerializeField] private string pressText1;
    [SerializeField] private string[] dialog1;
    [SerializeField] private bool nextLevel1; // Player reaches that level after the dialog
    [SerializeField] private int limitLevel1; // After that limit, the dialog is hidden to player.
    [Space]
    [Header("Dialog #2 Options")]
    [SerializeField] private string pressText2;
    [SerializeField] private string[] dialog2;
    [SerializeField] private bool nextLevel2;
    [SerializeField] private int limitLevel2;

    private Rigidbody2D rb;
    private bool triggerStay = false;
    private bool isDialogeStarted = false;
    private bool isDialogFinished = false;

    private int dialogIndex;


    private void Update()
    {
        if (LevelManager.instance.level < limitLevel1)
        {
            RunDialog(dialog1, ref nextLevel1);
        }
        if (LevelManager.instance.level < limitLevel2 && LevelManager.instance.level >= limitLevel1)
        {
            RunDialog(dialog2, ref nextLevel2);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggerStay = true;
            if (LevelManager.instance.level < limitLevel1)
            {
                ShowCanvas(pressText1);
            }
            if (LevelManager.instance.level < limitLevel2 && LevelManager.instance.level >= limitLevel1)
            {
                ShowCanvas(pressText2);
            }
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

    private void RunDialog(string[] dialog, ref bool nextLevel)
    {
        if (triggerStay && isDialogeStarted && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogIndex < dialog.Length)
            {
                canvasText.text = dialog[dialogIndex];
                dialogIndex++;
            }
            if (dialogIndex == dialog.Length)
            {
                isDialogFinished = true;
            }
            if (isDialogFinished)
            {
                if (nextLevel == true)
                {
                    nextLevel = false;
                    LevelManager.instance.levelUp();
                }
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
    private void ShowCanvas(string text)
    {
        canvasText.text = text;
        canvasText.gameObject.SetActive(true);
    }
}
    
