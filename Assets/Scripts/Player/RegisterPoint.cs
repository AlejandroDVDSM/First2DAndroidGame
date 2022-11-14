using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPoint : MonoBehaviour
{
    [SerializeField] GameObject scoreManagerGameObject;
    ScoreManager scoreManagerScript;

    void Start()
    {
        scoreManagerScript = scoreManagerGameObject.GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int score = collision.gameObject.GetComponent<ElementData>().Element.score;

        switch (collision.gameObject.tag)
        {
            case "BadElement":
                scoreManagerScript.SubstractScore(score);
                break;

            case "GoodElement":
                scoreManagerScript.AddScore(score);
                break;
        }

        Destroy(collision.gameObject);
    }
}
