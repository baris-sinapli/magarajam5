using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollideInformer : MonoBehaviour
{
    private AudioSource audioSource;
    

    enum Side {
        Right, 
        Left
    }

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField] Side side;
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private Animator DoorAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player Entered !!");
            canvasText.text = "Press <color=#E0E300>[E]</color> to open the door!";
            canvasText.gameObject.SetActive(true);
        }        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Key E Pressed");
                DoorAnimator.gameObject.SetActive(true);
                DoorAnimator.SetTrigger("Transition");
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player Left !!");
        canvasText.text = "";
        canvasText.gameObject.SetActive(false);

    }
}

