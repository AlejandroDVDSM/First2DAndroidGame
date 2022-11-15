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
    
    public void HideInstructions()
    {
        playButton.SetActive(true);
        instructionsButton.SetActive(true);
        quitButton.SetActive(true);
        titleGame.SetActive(true);

        pagesHolder.SetActive(false);
    }

    public void NextPage()
    {
        //pagesHolder.GetComponent<RectTransform>().position = new Vector3(-160, pagesHolder.transform.position.y, 0);
    }

    public void PrevPage()
    {

    }

}
