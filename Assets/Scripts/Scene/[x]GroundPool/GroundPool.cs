using UnityEngine;
using UnityEngine.Pool;

public class GroundPool : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    private float currentXSpawnPosition = 25f;

    private bool collectionChecks = true;
    private int maxPoolSize = 15;

    public IObjectPool<GameObject> m_pool { get; set;}
    
    void Start()
    {
        m_pool = new ObjectPool<GameObject>(CreateGround, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
        // 10 = capacity of the pool
    }

    public void SpawnGround() => m_pool.Get();

    public void ReleaseGround(GameObject ground) => m_pool.Release(ground);

    private GameObject CreateGround()
    {
        GameObject ground = Instantiate(groundPrefab, transform);
        ground.SetActive(false);

        return ground;
    }

    // Called when a ground is taken from the pool using Get
    private void OnTakeFromPool(GameObject ground)
    {
        // Move the ground to the currentXSpawnPosition
        ground.transform.position = new Vector3(currentXSpawnPosition, 2, 0);
        //Activate the ground
        ground.gameObject.SetActive(true);
    }

    // Called when a ground is returned to the pool using Release
    private void OnReturnedToPool(GameObject ground) => ground.gameObject.SetActive(false);

    // If the pool capacity is reached then any grounds returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    private void OnDestroyPoolObject(GameObject ground) => Destroy(ground);
}
