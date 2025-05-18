using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("�� ������ �ִ� ����")]
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
