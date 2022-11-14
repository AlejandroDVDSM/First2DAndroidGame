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
        switch(collision.gameObject.tag)
        {
            case "BadElement":
                scoreManagerScript.SubstractScore(1);
                break;

            case "GoodElement":
                scoreManagerScript.AddScore(1);
                break;
        }

        Destroy(collision.gameObject);
    }
}
