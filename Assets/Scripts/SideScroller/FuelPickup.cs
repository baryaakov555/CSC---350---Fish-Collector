using UnityEngine;

public class FuelPickup : Collectible
{
    public string fuelType = "basic";

    public override void ApplyEffect(EndlessShipController ship)
    {
        ship.fuel.Refill(fuelType);
        Debug.Log("Fuel after refill: " + ship.fuel.CurrentFuel);
        Destroy(gameObject);
    }
}
