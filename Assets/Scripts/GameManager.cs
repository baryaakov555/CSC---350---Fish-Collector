using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject fishPrefab;
    public List<GameObject> fishList = new List<GameObject>();

    [Header("Fuel Spawn Settings")]
    [SerializeField] private GameObject fuelPrefab;
    [SerializeField] private float spawnInterval = 10f;

    private float spawnTimer = 0f;

    public List<GameObject> fuelTanks = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        HandleFishPlacement();

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnFuelTank();
            spawnTimer = 0f;
        }
    }

    void HandleFishPlacement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;

            GameObject fish = Instantiate(fishPrefab, worldPosition, Quaternion.identity);
            fishList.Add(fish);
        }
    }

    void SpawnFuelTank()
    {
        Vector2 position = GetRandomWorldPosition();

        GameObject tank = Instantiate(fuelPrefab, position, Quaternion.identity);

        fuelTanks.Add(tank);
    }

    Vector2 GetRandomWorldPosition()
    {
        Camera camera = Camera.main;

        float x = Random.Range(0.1f, 0.9f);
        float y = Random.Range(0.1f, 0.9f);

        Vector3 viewPosition = new Vector3(x, y, 0);
        Vector3 worldPosition = camera.ViewportToWorldPoint(viewPosition);

        worldPosition.z = 0;

        return worldPosition;
    }
}