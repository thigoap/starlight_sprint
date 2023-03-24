using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour
{
    public Animator anim;
    
    public abstract void Collect();

    public void Disappear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
