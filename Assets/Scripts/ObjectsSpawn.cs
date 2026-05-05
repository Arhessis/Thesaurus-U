using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;
    public int amountToSpawn = 1;

    private float minX = -14f;
    private float maxX = 14f;
    private float minZ = -14f;
    private float maxZ = 14f;
    private float spawnHeight = 0.0f;

    [Header("Obstacle Avoidance")]
    public float checkRadius = 0.4f;
    public LayerMask obstaclesLayer; 
    public int maxAttempts = 100; 

    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnWithCheck();
        }
    }

    void SpawnWithCheck()
    {
        bool spawned = false;
        int attempts = 0;

        while (!spawned && attempts < maxAttempts)
        {
            attempts++;

            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            Vector3 randomPosition = new Vector3(randomX, spawnHeight, randomZ);

            if (!Physics.CheckSphere(randomPosition, checkRadius, obstaclesLayer))
            {
                Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
                Instantiate(objectToSpawn, randomPosition, rotation);
                spawned = true;
            }
        }

        if (!spawned)
        {
            Debug.LogWarning("Could not find a valid spawn location after " + maxAttempts + " attempts!");
        }
    }
}