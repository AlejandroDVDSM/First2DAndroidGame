using UnityEngine;


public class TriggerInstructionsMenu : MonoBehaviour
{
    [SerializeField] GameObject _titleGame, _playContainer, _quitButton, _scroll, _explosions;

    public void TriggerInstructions()
    {
        _titleGame.SetActive(false);
        _playContainer.SetActive(false);
        _quitButton.SetActive(false);
        _explosions.SetActive(false);

        _scroll.SetActive(true);
    }
    
    public void HideInstructions()
    {
        _titleGame.SetActive(true);
        _playContainer.SetActive(true);
        _quitButton.SetActive(true);
        _explosions.SetActive(true);

        _scroll.SetActive(false);
    }

}
