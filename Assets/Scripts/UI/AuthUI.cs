using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AuthUI : MonoBehaviour
{
    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] GameObject _errorMessage, _authenticateContainer, _playContainer;
    [SerializeField] Button _confirmButton;
    [SerializeField] FirebaseManager _firebaseManager;

    void Update()
    {
        /*if (_firebaseManager.IsUserAuthenticated)
        {
            _playContainer.SetActive(true);
        } else
        {
            _authenticateContainer.SetActive(false);
        }*/
    }

    public void SetConfirmButtonInteractivity()
    {
        if (NameIsGreaterThanMinLength())
        {
            _confirmButton.interactable = true;
            _errorMessage.SetActive(false);
        } else
        {
            _confirmButton.interactable = false;
            _errorMessage.SetActive(true);
        }
    }

    bool NameIsGreaterThanMinLength()
    {
        if (_nameInputField.text.Length >= 3) return true;

        return false;
    }

    public void HideAUthUI()
    {
        _authenticateContainer.SetActive(false);
    }
}
