using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    void Start()
    {      
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 2);
            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
        }      
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Parent"))
        {
            Debug.Log("EXTERMINATE!");
            Destroy(collider.gameObject);
        }
    }
}
