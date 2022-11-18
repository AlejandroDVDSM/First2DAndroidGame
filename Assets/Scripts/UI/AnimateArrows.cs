using System;
using UnityEngine;

public class AnimateArrows : MonoBehaviour
{
    bool _timeToGetClose = true;
    Vector3 _velocity = Vector3.zero;
    [SerializeField] float _smoothTime = .5f;

    Vector3 _originalPosition;
    Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;

        Vector3 auxPos = transform.position;
        auxPos.x -= 3f;
        _targetPosition = auxPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeToGetClose)
        {
            GetCloserToTargetPosition();
        } else
        {
            MoveAwayFromTargetPosition();
        }
    }

    void GetCloserToTargetPosition()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _smoothTime);

        var currentPosX = Math.Round(transform.position.x, 2);
        var targetPositionRoundedX = Math.Round(_targetPosition.x, 2);

        if (currentPosX == targetPositionRoundedX) _timeToGetClose = false;

    }
    
    void MoveAwayFromTargetPosition()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _originalPosition, ref _velocity, _smoothTime);

        var currentPosX = Math.Round(transform.position.x, 2);
        var originalPositionRoundedX = Math.Round(_originalPosition.x, 2);

        if (currentPosX == originalPositionRoundedX) _timeToGetClose = true;
    }
}
