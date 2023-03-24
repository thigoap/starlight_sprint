using UnityEngine;
using System.Collections;

public class FloatingBox : Enemy
{
    float speed = 2;
    bool goUp = false;

    void Update()
    {
        if (transform.position.y > 6)
            goUp = false;
        else if (transform.position.y < 1)
            goUp = true;

        if (goUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else 
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            TakeHit();
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

}
