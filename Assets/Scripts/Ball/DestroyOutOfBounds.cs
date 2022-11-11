using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float lowerLimit;

    private void Update()
    {
        if (transform.position.y <= lowerLimit) Destroy(this.gameObject);
    }
}
