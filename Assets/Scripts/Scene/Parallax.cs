using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float depth = 1;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        float realVelocity = GameManager.Instance.velocity / depth;
        
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -38)
            pos.x = 45.8f;

        transform.position = pos;
    }
}
