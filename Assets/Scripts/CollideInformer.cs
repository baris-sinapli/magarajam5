using System.Collections;
using TMPro;
using UnityEngine;

public class CollideInformer : MonoBehaviour
{
    private AudioSource audioSource;
    Camera cam;
    private GameObject player;
    private bool isKeyPressed = false;


    enum Side {
        Right, 
        Left
    }

    public void Awake()
    {
       audioSource = GetComponent<AudioSource>();
       cam = Camera.main;
       player = GameObject.FindGameObjectWithTag("Player");
    }

    [SerializeField] Side side;
    [SerializeField] private TextMeshProUGUI canvasText;
    [SerializeField] private Animator DoorAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player Entered !!");
            canvasText.text = "Kapýyý açmak için <color=#E0E300>[E]</color> tuþuna basýn";
            canvasText.gameObject.SetActive(true);
        }        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!isKeyPressed && Input.GetKey(KeyCode.E))
            {
                isKeyPressed = true;
                DoorAnimator.SetBool("Transition", true);
                audioSource.Play();
                StartCoroutine(MoveCharacterNextRoom());



            }

            if(Input.GetKeyUp(KeyCode.E))
            {
                isKeyPressed = false;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvasText.text = "";
        canvasText.gameObject.SetActive(false);
        DoorAnimator.SetBool("Transition", false);
        isKeyPressed = false;
    }
    
    private IEnumerator MoveCharacterNextRoom(){
        yield return new WaitForSeconds(1);
        if (side == Side.Left)
        {
            
            //player.transform.position.x = player.transform.position.x - 1920f;
            player.transform.position += new Vector3(-5f, 0, 0);
            cam.transform.position += new Vector3(-15.75f, 0, 0);
        }
        else
        {
            player.transform.position += new Vector3(5f, 0, 0);
            cam.transform.position += new Vector3(15.75f, 0, 0);
        }
    }
}

