using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public string fuelType = "basic";

    private void OnTriggerEnter2D(Collider2D other)
    {
        EndlessShipController ship =
            other.GetComponent<EndlessShipController>();

        if (ship == null) return;

        ship.fuel.Refill(fuelType);
        Destroy(gameObject);
    }
}
