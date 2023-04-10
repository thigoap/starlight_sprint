using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    SkinController skinController;
    KitController kitController;
    
    string skinName;
    string kitName;
    
    int maxLife = 2;
    public static int life;

    void Start()
    {
        skinName = PlayerPrefs.GetString("selectedSkin");
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
        kitName = PlayerPrefs.GetString("selectedKit");
        kitController = GameObject.Find("Player " + kitName + "(Clone)").GetComponent<KitController>();

        life = maxLife;
    }

    public void GainLife(int amount)
    {
        life = life + amount;
        if (life == 1)
            StartCoroutine(kitController.RecoverKit());
    }

    public void LoseLife(int amount)
    {
        if (life >= 1)
        {
            // deactivates polygon collider from obstacle - moved to Obstacle script
            // collider.GetComponent<PolygonCollider2D>().enabled = false;
            // Debug.Log("Hit Obstacle");
            life = life - amount;
            // StartCoroutine(skinController.DamagePlayer()); 
            StartCoroutine(kitController.DamagePlayer());
        }
        // else if (life == 1)
        // {
        //     life = life - amount;
        //     kitController.LoseKit();
        // }
        else if (life == 0)
        {
            SkinController.isDead = true;
            GameManager.Instance.GameOver();  
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
