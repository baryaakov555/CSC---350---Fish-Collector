using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject fuelPrefab;
    public float spawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFuel();
            timer = 0f;
        }
    }

    void SpawnFuel()
    {
        Vector3 spawnPos = new Vector3(
            Camera.main.transform.position.x + 9f,
            Random.Range(-4f, 4f),
            0f
        );

        Instantiate(fuelPrefab, spawnPos, Quaternion.identity);
    }
}
