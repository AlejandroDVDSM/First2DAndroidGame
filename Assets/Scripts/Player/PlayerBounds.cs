using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [SerializeField] float leftBound;
    [SerializeField] float rightBound;

    public bool IsInBounds(float touchPositionX)
    {
        if (touchPositionX < leftBound || touchPositionX > rightBound) return false;
        return true;
    }
}
