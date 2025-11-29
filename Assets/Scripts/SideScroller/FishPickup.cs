using UnityEngine;

public class FishPickup : Collectible
{
    public int scoreValue = 10;

    public override void ApplyEffect(EndlessShipController ship)
    {
        ScoreManager.Instance.Add(scoreValue);
        Destroy(gameObject);
    }
}
