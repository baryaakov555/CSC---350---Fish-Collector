using UnityEngine;

public class Fuel
{
    public float Amount { get; private set; }
    public float MaxAmount { get; private set; }

    public Fuel(float initial, float max)
    {
        MaxAmount = max;
        Amount = initial;
    }

    public void Consume(float value)
    {
        Amount -= value;
        if (Amount < 0)
        {
            Amount = 0;
        }
    }

    public void Add(float value)
    {
        Amount += value;
        if (Amount > MaxAmount)
        {
            Amount = MaxAmount;
        }
    }

    public bool IsEmpty()
    {
        return Amount <= 0;
    }
}