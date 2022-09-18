using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene2 : MonoBehaviour
{

    [SerializeField] private int carCrashEnd;
    [SerializeField] private int bustedEnd;
    [SerializeField] GameObject ending;
    [SerializeField] GameObject hoca;

    private void Update()
    {
        if (hoca.GetComponent<CutsceneManager>().isFinished)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
