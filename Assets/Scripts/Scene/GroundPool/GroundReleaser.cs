using UnityEngine;

public class GroundReleaser : MonoBehaviour
{

    [SerializeField] private GroundPool groundPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            groundPool.ReleaseGround(collision.gameObject);
            groundPool.SpawnGround();
        }
    }

}
