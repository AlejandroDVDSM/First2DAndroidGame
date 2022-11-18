using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D _myCollider;

    Touch _touch;
    Vector2 _touchPosition;

    bool _moveAllowed;
    PlayerBounds _playerBounds;

    // Start is called before the first frame update
    void Start()
    {
        _myCollider = GetComponent<Collider2D>();
        _playerBounds = GetComponent<PlayerBounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(_touchPosition);
                    if (_myCollider == touchedCollider) _moveAllowed = true;
                    break;

                case TouchPhase.Moved:
                    if (_moveAllowed && _playerBounds.IsInBounds(_touchPosition.x)) transform.position = new Vector2(_touchPosition.x, transform.position.y);
                    break;

                case TouchPhase.Ended:
                    _moveAllowed = false;
                    break;
            }
        }
    }
}