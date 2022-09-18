using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarBroke : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private string uiText; 
    [SerializeField] private string uiText2;
    [SerializeField] private string uiText3; 
    [SerializeField] private int requiredLevel;
    [SerializeField] private int requiredLevel2;
    [SerializeField] private int requiredLevel3;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private AudioSource audioSource2;

    private AudioSource audioSource;
    private bool triggerStay = false;
    private bool isBroken = false;
    private bool isCutted = false;
    private bool isClosed = false;


    private void Awake()
    {
        gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isBroken && isCutted)
        {
            if (triggerStay && !isClosed && LevelManager.instance.level >= requiredLevel3)
            {
                uiText = uiText3;
                if (Input.GetKey(interactKey))
                {
                    isClosed = true;
                    LevelManager.instance.levelUp();
                    uiText = "";
                    canvasText.text = uiText;
                }
            }
        }
        
        if (isBroken)
        {
            if (triggerStay && !isCutted && LevelManager.instance.level >= requiredLevel2)
            {
                uiText = uiText2;
                if (Input.GetKey(KeyCode.E))
                {
                    LevelManager.instance.levelUp();
                    audioSource2.Play();
                    isCutted = true;
                    uiText = "";
                    canvasText.text = uiText;
                }
            }
                return;
        }
        if (LevelManager.instance.level >= requiredLevel)
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (triggerStay && !isBroken && Input.GetKey(interactKey))
        {
            isBroken = true;
            uiText = "";
            canvasText.text = uiText;
            LevelManager.instance.levelUp();
            //kaput kýrma sesi
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggerStay = true;
            canvasText.text = uiText;
            canvasText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        triggerStay = false;
        canvasText.text = "";
        canvasText.gameObject.SetActive(false);
    }
}
