using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject BackgroundUI;
    private void Start()
    {
        BackgroundUI.SetActive(false);
    }

}
