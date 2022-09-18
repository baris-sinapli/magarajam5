using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int level;
    void Start()
    {
        level = 0;
    }

    public void levelUp()
    {
        level++;
        Debug.Log(level);
    }
}
