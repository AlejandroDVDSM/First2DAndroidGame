using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

public class LocateSelector : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _languagueDropdown;
    bool _active = false;

    public void ChangeLocale()
    {
        if (_active) return;

        StartCoroutine(SetLocale(_languagueDropdown.value));
    }

    IEnumerator SetLocale(int localeID)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        _active = false;
    }
}
