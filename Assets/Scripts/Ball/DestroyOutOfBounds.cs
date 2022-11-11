using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float loweLimit;

    private void Update()
    {
        if (transform.position.y <= loweLimit) Destroy(this.gameObject);
    }


}
