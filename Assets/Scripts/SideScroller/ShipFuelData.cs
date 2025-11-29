using System.Collections.Generic;
using UnityEngine;

public class ShipFuelData
{
    private float currentFuel;
    private float maxFuel;

    private Dictionary<string, float> fuelTypes =
        new Dictionary<string, float>();

    private Queue<float> usageHistory =
        new Queue<float>();

    public float CurrentFuel => currentFuel;
    public bool IsEmpty => currentFuel <= 0;

    public ShipFuelData(float max)
    {
        maxFuel = max;
        currentFuel = max;

        fuelTypes["basic"] = 25f;
    }

    public void Consume(float amount)
    {
        currentFuel = Mathf.Max(0, currentFuel - amount);

        usageHistory.Enqueue(amount);
        if (usageHistory.Count > 25)
            usageHistory.Dequeue();
    }

    public void Refill(string type)
    {
        if (!fuelTypes.ContainsKey(type)) return;

        currentFuel = Mathf.Min(
            maxFuel,
            currentFuel + fuelTypes[type]
        );
    }
}
