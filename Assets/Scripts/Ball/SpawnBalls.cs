using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    Vector2 respawnPos;
    float randomX;

    void Start()
    {
        InvokeRepeating("SpawnBall", 1.0f, 1.5f);
    }

    void SpawnBall()
    {
        randomX = Random.Range(-2.0f, 2.0f);
        respawnPos = new Vector2(randomX, ballPrefab.transform.position.y);
        Instantiate(ballPrefab, respawnPos, transform.rotation);
    }
}
