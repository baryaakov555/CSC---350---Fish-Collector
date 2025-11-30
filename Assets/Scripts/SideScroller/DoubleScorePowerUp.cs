using UnityEngine;

public class DoubleScorePowerUp : Collectible
{
    public float duration = 5f;

    public override void ApplyEffect(EndlessShipController ship)
    {
        ScoreManager.Instance.EnableDoubleScore(duration);
        Destroy(gameObject);
    }
}
