using System.Collections;
using System.Collections.Generic;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            audioSource.Play();
            Debug.Log("Player !!");
        }        
    }
}

