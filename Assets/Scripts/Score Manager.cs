using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Tooltip("���� ����")]
    public int score = 0;

    [Tooltip("������ ǥ���� UI Text")]
    public TMP_Text scoreText;

    private void Awake()
    {
        if ( Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if ( scoreText != null )
        {
            scoreText.text = "Score : " + score;
        }
    }
}
