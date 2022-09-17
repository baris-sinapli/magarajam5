using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollideInformer : MonoBehaviour
{
    private AudioSource audioSource;
   // Camera cam;

    enum Side {
        Right, 
        Left
    }

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       // cam = Camera.main;
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
                DoorAnimator.SetBool("Transition", true);
                audioSource.Play();
                moveCharacterNextRoom(other.gameObject);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvasText.text = "";
        canvasText.gameObject.SetActive(false);
        DoorAnimator.SetBool("Transition", false);
    }
    
    private void moveCharacterNextRoom(GameObject player){
        if(side == Side.Left){
            player.transform.position.x = player.transform.position.x - 1920f;
        } else player.transform.position.x = player.transform.position.x + 1920f;
    }
}

