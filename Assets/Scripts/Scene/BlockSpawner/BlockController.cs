using UnityEngine;

public class BlockController : MonoBehaviour
{
    // public float groundHeight = 1f;
    [SerializeField] private Rigidbody2D rb;

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-1 * GameManager.Instance.velocity, 0);          
    }
}
