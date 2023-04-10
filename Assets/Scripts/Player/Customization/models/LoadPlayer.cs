using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    public GameObject[] skinPrefabs; 
    public GameObject[] kitPrefabs; 
    public Transform spawnPoint;

    void Start()
    {
        int selectedSkin = PlayerPrefs.GetInt("selectedSkin");
        int selectedKit = PlayerPrefs.GetInt("selectedKit");
        GameObject skinPrefab = skinPrefabs[selectedSkin];
        GameObject kitPrefab = kitPrefabs[selectedKit];
        GameObject skinClone = Instantiate(skinPrefab, spawnPoint.position, Quaternion.identity);
        GameObject kitClone = Instantiate(kitPrefab, spawnPoint.position, Quaternion.identity);
    }
}
