using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetButtonInteractivity : MonoBehaviour
{

    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] GameObject _errorMessage;
    [SerializeField] Button _confirmButton;

    public void SetConfirmButtonInteractivity()
    {
        if (CheckMinLength())
        {
            _confirmButton.interactable = true;
            Debug.Log(_confirmButton.interactable);
            _errorMessage.SetActive(false);
        } else
        {
            _confirmButton.interactable = false;
            _errorMessage.SetActive(true);
        }
        
    }

    bool CheckMinLength()
    {
        if (_nameInputField.text.Length >= 3) return true;

        return false;
    }
}
