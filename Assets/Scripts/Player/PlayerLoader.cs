using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    private GameObject skinPrefab;
    private GameObject kitPrefab;
    private string skinName;
    private string kitName;

    public Transform parent;
    
    /*
    Skin Male 01 = Player Skin Male 01
    Kit Male 01 = Player Kit Male 01
    */

    void Awake()
    {
        skinName = PlayerPrefs.GetString("selectedSkin");
        kitName = PlayerPrefs.GetString("selectedKit");

        skinPrefab = Resources.Load<GameObject>("Player " + skinName);
        Instantiate(skinPrefab, parent);
        
        kitPrefab = Resources.Load<GameObject>("Player " + kitName);
        Instantiate(kitPrefab, parent);
        
    }

}
