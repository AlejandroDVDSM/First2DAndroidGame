using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    [SerializeField] GameObject elementPrefab;
    [SerializeField] float minValueAllowed;
    [SerializeField] float maxValueAllowed;

    Vector2 respawnPos;
    float randomX;

    void Start()
    {
        InvokeRepeating("SpawnElement", 1.0f, 1.5f);
    }

    void SpawnElement()
    {
        randomX = Random.Range(minValueAllowed, maxValueAllowed);
        respawnPos = new Vector2(randomX, elementPrefab.transform.position.y);
        Instantiate(elementPrefab, respawnPos, transform.rotation);
    }
}
