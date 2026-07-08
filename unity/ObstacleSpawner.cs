using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject jumpObstaclePrefab;
    public GameObject slideObstaclePrefab;

    public float spawnInterval = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacleToSpawn;

        // 50% chance of jump obstacle or slide obstacle
        if (Random.value < 0.5f)
        {
            obstacleToSpawn = jumpObstaclePrefab;
        }
        else
        {
            obstacleToSpawn = slideObstaclePrefab;
        }

        Instantiate(
            obstacleToSpawn,
            new Vector3(0, 1, 20),
            Quaternion.identity
        );
    }
}