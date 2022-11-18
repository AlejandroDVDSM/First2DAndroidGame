using UnityEngine;


public class TriggerInstructionsMenu : MonoBehaviour
{
    [SerializeField] GameObject titleGame, playContainer, quitButton, scroll, explosions;

    public void TriggerInstructions()
    {
        titleGame.SetActive(false);
        playContainer.SetActive(false);
        quitButton.SetActive(false);
        explosions.SetActive(false);

        scroll.SetActive(true);
    }
    
    public void HideInstructions()
    {
        titleGame.SetActive(true);
        playContainer.SetActive(true);
        quitButton.SetActive(true);
        explosions.SetActive(true);

        scroll.SetActive(false);
    }

}
