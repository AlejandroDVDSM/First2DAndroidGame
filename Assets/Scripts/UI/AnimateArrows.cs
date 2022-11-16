using System;
using UnityEngine;

public class AnimateArrows : MonoBehaviour
{
    bool timeToGetClose = true;
    Vector3 velocity = Vector3.zero;
    [SerializeField] float smoothTime = .5f;

    Vector3 originalPosition;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        Vector3 auxPos = transform.position;
        auxPos.x -= 3f;
        targetPosition = auxPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToGetClose)
        {
            Debug.Log(true);
            GetCloserToTargetPosition();
        } else
        {
            Debug.Log(false);
            MoveAwayFromTargetPosition();
        }
    }

    void GetCloserToTargetPosition()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        var currentPosX = Math.Round(transform.position.x, 2);
        var targetPositionRoundedX = Math.Round(targetPosition.x, 2);

        //Debug.LogFormat("currentPosX: {0}, targetPositionX: {1}, {2}", currentPosX, targetPositionX, currentPosX == targetPositionX);

        if (currentPosX == targetPositionRoundedX) timeToGetClose = false;

    }
    
    void MoveAwayFromTargetPosition()
    {
        transform.position = Vector3.SmoothDamp(transform.position, originalPosition, ref velocity, smoothTime);

        var currentPosX = Math.Round(transform.position.x, 2);
        var originalPositionRoundedX = Math.Round(originalPosition.x, 2);

        if (currentPosX == originalPositionRoundedX) timeToGetClose = true;
    }
}
