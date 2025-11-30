using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; }

    private bool doubleScore;
    private float doubleScoreTimer;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!doubleScore) return;

        doubleScoreTimer -= Time.deltaTime;
        if (doubleScoreTimer <= 0f)
        {
            doubleScore = false;
            if (PowerUpUI.Instance != null)
                PowerUpUI.Instance.HideDoubleScore();
        }
    }


    public void Add(int amount)
    {
        if (doubleScore)
            amount *= 2;

        Score += amount;
    }

    public void EnableDoubleScore(float duration)
    {
        doubleScore = true;
        doubleScoreTimer = duration;

        if (PowerUpUI.Instance != null)
            PowerUpUI.Instance.ShowDoubleScore();
    }


    public void ResetScore()
    {
        Score = 0;
        PowerUpUI.Instance.HideDoubleScore();
    }
}
