using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene1 : MonoBehaviour
{
    private bool triggerStay = false;
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private string text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerStay && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Scene02");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggerStay = true;
            canvasText.text = text;
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
