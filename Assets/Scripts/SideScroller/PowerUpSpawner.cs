using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        float camX = Camera.main.transform.position.x + 9f;
        float y = Random.Range(-4f, 4f);

        int index = Random.Range(0, powerUpPrefabs.Length);

        Instantiate(
            powerUpPrefabs[index],
            new Vector3(camX, y, 0f),
            Quaternion.identity
        );
    }
}
