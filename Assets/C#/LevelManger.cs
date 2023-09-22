using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger instance;
    public Transform Player;
    public int Score;
    public int Levelitems;
    bool toto = false;
    public Transform[] particles;
    private void Awake()
    {

        instance = this;
    }
}

