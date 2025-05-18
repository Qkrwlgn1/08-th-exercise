using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("이 코인이 주는 점수")]
    public int scoreCoin = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreCoin);

            Destroy(gameObject);
        }
    }
}
