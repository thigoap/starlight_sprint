using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private LevelSavedData MyData = new LevelSavedData();

    public bool mainLevel;

    void Start() {
        mainLevel = true;    
    }


    void Update() {
        
    }
}

[System.Serializable]
public struct LevelSavedData
{
    public bool mainLevel;
    
}