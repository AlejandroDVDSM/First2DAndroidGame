using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    [SerializeField] float _minXAllowed, _maxXAllowed;
    [SerializeField] GameObject[] _badElements, _goodElements;

    float _randomX;
    Vector2 _respawnPos;
    int _randomElement;

    void Start()
    {
        InvokeRepeating("SpawnElement", 1.0f, 1.65f);
    }

    void SpawnElement()
    {
        _randomX = Random.Range(_minXAllowed, _maxXAllowed);
        _respawnPos = new Vector2(_randomX, transform.position.y);
        int typeOfElement = Random.Range(-1, 1);
        ChooseElementToSpawn(typeOfElement);
    }

    void ChooseElementToSpawn(int typeOfElement)
    {
        switch (typeOfElement)
        {
            case -1:
                _randomElement = Random.Range(0, _badElements.Length);
                var badElement = Instantiate(_badElements[_randomElement], _respawnPos, transform.rotation);
                break;

            case 0:
                _randomElement = Random.Range(0, _goodElements.Length);
                var goodElement = Instantiate(_goodElements[_randomElement], _respawnPos, transform.rotation);
                goodElement.GetComponent<Rigidbody2D>().gravityScale = .9f;
                break;
        }
    }
}
