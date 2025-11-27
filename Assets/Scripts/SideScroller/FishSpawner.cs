using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFish), 1f, spawnInterval);
    }

    void SpawnFish()
    {
        float y = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(12f, y, 0);

        Instantiate(fishPrefab, spawnPos, Quaternion.identity);
    }
}
