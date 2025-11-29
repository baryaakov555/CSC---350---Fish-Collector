using TMPro;
using UnityEngine;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private EndlessShipController ship;

    void Update()
    {
        if (label == null || ship == null || ship.fuel == null)
            return;

        label.text = "Fuel: " + Mathf.CeilToInt(ship.fuel.CurrentFuel);
    }
}
