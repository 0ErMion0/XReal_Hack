using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4Sys : MonoBehaviour
{
    public static Chapter4Sys instance { get; private set; }
    public bool isClear;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
}
