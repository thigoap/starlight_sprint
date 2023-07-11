using UnityEngine;

// https://www.youtube.com/watch?v=CcTj8es83zA

public class GroundController : MonoBehaviour
{

    public float groundHeight = 2f;
    [SerializeField] private Rigidbody2D rb;


    void FixedUpdate()
    {
        rb.velocity = new Vector2(-1 * GameManager.Instance.velocity, 0);
    }
}
