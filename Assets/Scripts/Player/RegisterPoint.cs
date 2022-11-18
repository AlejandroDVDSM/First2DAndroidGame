using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPoint : MonoBehaviour
{
    [SerializeField] ScoreManager _scoreManagerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int score = collision.gameObject.GetComponent<ElementData>().Element.score;

        switch (collision.gameObject.tag)
        {
            case "BadElement":
                _scoreManagerScript.SubstractScore(score);
                break;

            case "GoodElement":
                _scoreManagerScript.AddScore(score);
                break;

            case "Upgrade":
                Debug.Log(collision.gameObject.name);
                break;
        }

        Destroy(collision.gameObject);
    }
}
