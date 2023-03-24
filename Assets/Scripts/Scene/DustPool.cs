using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustPool : MonoBehaviour
{
    public static DustPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField]
    private GameObject dustPrefab;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        GameObject dustGO = Instantiate(dustPrefab, new Vector3(-10, -10, 0), Quaternion.identity);
        dustGO.SetActive(false);
        pooledObjects.Add(dustGO);
    }


    public GameObject GetPooledOject()
    {
        return pooledObjects[0];
    }

    public void StopDustEffect()
    {
        pooledObjects[0].gameObject.SetActive(false);
    }
    
}
