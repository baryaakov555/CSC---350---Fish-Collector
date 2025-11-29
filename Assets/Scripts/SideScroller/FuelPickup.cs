using UnityEngine;

public class FuelPickup : Collectible
{
    public string fuelType = "basic";
    public int scoreValue = 5;

    public override void ApplyEffect(EndlessShipController ship)
    {
        ship.fuel.Refill(fuelType);

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.Add(scoreValue);
        }

        Destroy(gameObject);
    }
}
