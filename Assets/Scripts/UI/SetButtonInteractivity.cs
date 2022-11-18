using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetButtonInteractivity : MonoBehaviour
{

    [SerializeField] Button _confirmButton;
    TMP_InputField _nameInputField;
    [SerializeField] GameObject _errorMessage;
    
    void Start()
    {
        _nameInputField =  GetComponent<TMP_InputField>();
        
    }

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

    private bool CheckMinLength()
    {
        if (_nameInputField.text.Length >= 3) return true;

        return false;
    }
}
