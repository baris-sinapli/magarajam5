using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int levelToChange;
    [SerializeField] private int levelToRemove;
    [SerializeField] private float size;

    void Update()
    {
        if(LevelManager.instance.level == levelToRemove)
        {
            transform.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        }
        if(LevelManager.instance.level == levelToChange)
        {
            if(transform.GetComponent<Animator>() == true)
            {
                transform.GetComponent<Animator>().enabled = false;
            }
            transform.GetComponent<SpriteRenderer>().sprite = sprite;
            transform.localScale = new Vector3(size, size, size);
        }        
    }
}
