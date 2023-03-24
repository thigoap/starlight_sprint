using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // public static CapsuleCollider2D capsuleCollider2D;
    PlayerController playerController;
    int maxLife = 1;
    [SerializeField] int life;

    void Start()
    {
        // capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        life = maxLife;
    }

    void Update()
    {
        
    }

    public void GainLife(int amount)
    {
        life = life + amount;
    }

    public void LoseLife(int amount)
    {
        if (life > 0)
        {
            // deactivates polygon collider from obstacle - moved to Obstacle script
            // collider.GetComponent<PolygonCollider2D>().enabled = false;
            // Debug.Log("Hit Obstacle");
            life = life - amount;
            StartCoroutine(playerController.DamagePlayer());
            
        }
        else if (life == 0)
        {
            PlayerController.isDead = true;
            GameManager.Instance.GameOver();  
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Dead"))
        {
            PlayerController.isDead = true;
            GameManager.Instance.GameOver();           
        }
    }
}
