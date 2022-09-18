using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene2 : MonoBehaviour
{

    [SerializeField] private int carCrashEnd;
    [SerializeField] private int bustedEnd;
    private void Update()
    {
        if (LevelManager.instance.level == carCrashEnd)
        {
            
        }
        if (LevelManager.instance.level == bustedEnd)
        {

        }
    }
}
