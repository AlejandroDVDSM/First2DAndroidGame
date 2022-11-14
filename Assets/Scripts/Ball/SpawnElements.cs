using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    [SerializeField] GameObject elementPrefab;
    [SerializeField] float minValueAllowed, maxValueAllowed;
    [SerializeField] GameObject[] badElements, goodElements, upgrades;

    float randomX;
    Vector2 respawnPos;
    int randomElement;

    void Start()
    {
        InvokeRepeating("SpawnElement", 1.0f, 1.65f);
    }

    void SpawnElement()
    {
        randomX = Random.Range(minValueAllowed, maxValueAllowed);
        respawnPos = new Vector2(randomX, transform.position.y);
        randomElement = Random.Range(0, badElements.Length);
        int typeOfElement = Random.Range(-1, 2);
        ChooseElementToSpawn(typeOfElement);
    }

    void ChooseElementToSpawn(int typeOfElement)
    {
        switch (typeOfElement)
        {
            case -1:
                randomElement = Random.Range(0, badElements.Length);
                Instantiate(badElements[randomElement], respawnPos, transform.rotation);
                break;

            case 0:
                randomElement = Random.Range(0, goodElements.Length);
                Instantiate(goodElements[randomElement], respawnPos, transform.rotation);
                break;

            case 1:
                randomElement = Random.Range(0, upgrades.Length);
                Instantiate(upgrades[randomElement], respawnPos, transform.rotation);
                break;
        }
    }
}
