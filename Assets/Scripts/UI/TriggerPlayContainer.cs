using UnityEngine;

public class TriggerPlayContainer : MonoBehaviour
{
    [SerializeField] GameObject _playContainer;

    public void ShowPlayContainer()
    {
        _playContainer.SetActive(true);
    }
}
