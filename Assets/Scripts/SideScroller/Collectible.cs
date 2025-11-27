using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public abstract void ApplyEffect(EndlessShipController ship);
}
