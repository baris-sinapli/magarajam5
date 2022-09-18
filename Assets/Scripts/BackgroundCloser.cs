using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCloser : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject cutsceneManager;
    // Update is called once per frame
    void Update()
    {
        if(cutsceneManager.GetComponent<CutsceneManager>().isFinished)
        {
            background.SetActive(false);
        }
    }
}
