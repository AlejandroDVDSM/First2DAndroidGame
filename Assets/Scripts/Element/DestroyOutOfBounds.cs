using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float _lowerLimit;

    private void Update()
    {
        if (transform.position.y <= _lowerLimit) Destroy(this.gameObject);
    }
}
