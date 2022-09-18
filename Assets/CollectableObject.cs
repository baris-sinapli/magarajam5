using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private string uiText;
    [SerializeField] private int requiredLevel;
    [SerializeField] private KeyCode interactKey;
    private bool triggerStay = false;


    private void Awake()
    {
        gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if(LevelManager.instance.level >= requiredLevel)
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (triggerStay && Input.GetKey(interactKey))
        {
            gameObject.SetActive(false);
            LevelManager.instance.levelUp(); 
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
