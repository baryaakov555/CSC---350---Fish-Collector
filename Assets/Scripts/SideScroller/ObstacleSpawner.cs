using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Vector3 spawnPos = new Vector3(
                Camera.main.transform.position.x + 10f,
                Random.Range(-4f, 4f),
                0f
            );

            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }
}
