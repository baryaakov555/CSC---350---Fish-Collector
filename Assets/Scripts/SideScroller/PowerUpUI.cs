using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    public static PowerUpUI Instance;

    [SerializeField] private Image doubleScoreIcon;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        doubleScoreIcon.enabled = false;
    }

    public void ShowDoubleScore()
    {
        doubleScoreIcon.enabled = true;
    }

    public void HideDoubleScore()
    {
        doubleScoreIcon.enabled = false;
    }
}
