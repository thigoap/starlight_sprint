using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPool : MonoBehaviour
{
    public static DiamondPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField]
    private GameObject diamondPrefab;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        GameObject diamondGO = Instantiate(diamondPrefab, new Vector3(-10, -10, 0), Quaternion.identity);
        diamondGO.SetActive(false);
        pooledObjects.Add(diamondGO);
    }


    public GameObject GetPooledOject()
    {
        return pooledObjects[0];
    }

    public void StopDiamondEffect()
    {
        pooledObjects[0].gameObject.SetActive(false);
    }
    
}

