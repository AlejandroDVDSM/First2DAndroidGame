using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerInstructionsMenu : MonoBehaviour
{
    [SerializeField] GameObject playButton, instructionsButton, quitButton, titleGame, pagesHolder;

    public void TriggerInstructions()
    {
        playButton.SetActive(false);
        instructionsButton.SetActive(false);
        quitButton.SetActive(false);
        titleGame.SetActive(false);

        pagesHolder.SetActive(true);
    }

    public void NextPage()
    {

    }

    public void PrevPage()
    {

    }

}
