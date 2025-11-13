using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject fishPrefab;
    public List<GameObject> fishList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        HandleFishPlacement();
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
}