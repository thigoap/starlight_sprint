using UnityEngine;

public class BlockReleaser : MonoBehaviour
{

    [SerializeField] private BlockSpawner blockSpawner;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Block"))
        {
            blockSpawner.SpawnBlock();
            Destroy(collider.gameObject);
        }
    }

}
