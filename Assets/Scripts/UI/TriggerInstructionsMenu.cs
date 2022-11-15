using UnityEngine;


public class TriggerInstructionsMenu : MonoBehaviour
{
    [SerializeField] GameObject playButton, instructionsButton, quitButton, titleGame, scroll, explosions;

    public void TriggerInstructions()
    {
        playButton.SetActive(false);
        instructionsButton.SetActive(false);
        quitButton.SetActive(false);
        titleGame.SetActive(false);
        explosions.SetActive(false);

        scroll.SetActive(true);
    }
    
    public void HideInstructions()
    {
        playButton.SetActive(true);
        instructionsButton.SetActive(true);
        quitButton.SetActive(true);
        titleGame.SetActive(true);
        explosions.SetActive(true);

        scroll.SetActive(false);
    }

}
