using UnityEngine;

public class InvincibilityPowerUp : Collectible
{
    public float duration = 5f;

    public override void ApplyEffect(EndlessShipController ship)
    {
        ship.EnableInvincibility(duration);
        Destroy(gameObject);
    }
}
