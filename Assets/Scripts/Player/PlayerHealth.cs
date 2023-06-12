using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    SkinController skinController;
    KitController kitController;
    
    string skinName;
    string kitName;
    
    public int maxLife = 2;
    [SerializeField] public static int life;
    public int lifeinscreen;

    void Start()
    {
        skinName = PlayerPrefs.GetString("selectedSkin");
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
        kitName = PlayerPrefs.GetString("selectedKit");
        kitController = GameObject.Find("Player " + kitName + "(Clone)").GetComponent<KitController>();

        life = maxLife;
        lifeinscreen = life;
    }

    public void GainLife(int amount)
    {
        if (life < maxLife)
        {
            lifeinscreen = life;
            if (life == 1)
            {
                kitController.HideLife();
                Debug.Log("Hide Life");
            }
            if (life == 0)
            {
                StartCoroutine(kitController.RecoverKit());
                kitController.ShowLife();
            }
            life++;
            lifeinscreen = life;
        }
    }

    public void LoseLife(int amount)
    {
        if (life >= 1)
        {
            // deactivates polygon collider from obstacle - moved to Obstacle script
            // collider.GetComponent<PolygonCollider2D>().enabled = false;
            // Debug.Log("Hit Obstacle");
            life = life - amount;
            lifeinscreen = life;
            // StartCoroutine(skinController.DamagePlayer()); 
            StartCoroutine(kitController.DamagePlayer());
        }
        else if (life == 0)
        {
            SkinController.isDead = true;
            GameManager.Instance.GameOver();  
        }

        if (life == 1)
        {
            kitController.ShowLife();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Dead"))
        {
            SkinController.isDead = true;
            
            GameManager.Instance.GameOver();           
        }
    }
}
