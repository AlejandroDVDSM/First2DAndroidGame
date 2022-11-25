using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    [SerializeField] float _minXAllowed, _maxXAllowed;
    [SerializeField] GameObject[] _badElements, _goodElements;

    float _randomX;
    Vector2 _respawnPos;

    int _randomTypeOfElement;
    float _randomSpeed;

    void Start()
    {
        InvokeRepeating("SpawnElement", .5f, 1.5f);
    }

    void SpawnElement()
    {
        SetRandomValues();
        switch (_randomTypeOfElement)
        {
            case 0:
                var randomBadElementIndex = Random.Range(0, _badElements.Length);
                var badElement = Instantiate(_badElements[randomBadElementIndex], _respawnPos, transform.rotation);
                badElement.GetComponent<Rigidbody2D>().gravityScale = _randomSpeed;
                break;

            case 1:
                var randomGoodElementIndex = Random.Range(0, _goodElements.Length);
                var goodElement = Instantiate(_goodElements[randomGoodElementIndex], _respawnPos, transform.rotation);
                goodElement.GetComponent<Rigidbody2D>().gravityScale = _randomSpeed;
                break;

        }
    }

    void SetRandomValues()
    {
        _randomX = Random.Range(_minXAllowed, _maxXAllowed);
        _respawnPos = new Vector2(_randomX, transform.position.y);

        _randomTypeOfElement = Random.Range(0, 2);

        _randomSpeed = Random.Range(.2f, .8f);
    }
}
