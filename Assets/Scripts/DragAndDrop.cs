using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D myCollider;

    Touch touch;
    Vector2 touchPosition;

    bool moveAllowed;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (myCollider == touchedCollider) moveAllowed = true;
                    break;

                case TouchPhase.Moved:
                    if (moveAllowed) transform.position = touchPosition;
                    break;

                case TouchPhase.Ended:
                    moveAllowed = false;
                    break;
            }
        }
    }

    bool PlayerTouchedCapsule(Touch touch)
    {
        if (touch.phase == TouchPhase.Began) return true;

        return false;
    }
}
