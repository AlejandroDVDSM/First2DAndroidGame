using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
using System;

public class FirebaseDB : MonoBehaviour
{
    [SerializeField] TMP_InputField _userName;
    [SerializeField] GameObject _playContainer, _authenticateContainer;

    DatabaseReference _dbReference;
    string _userID;

    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        User newUser = new User(_userID, _userName.text, 0);
        string json = JsonUtility.ToJson(newUser);

        _dbReference.Child("users").Child(_userID).SetRawJsonValueAsync(json);
        Debug.LogFormat("New user created: {0}, {1}", _userName.text, _userID);
    }

    IEnumerator IsUserInDB(Action<bool> onCallback)
    {
        var userData = _dbReference.Child("users").GetValueAsync();
        yield return new WaitUntil(predicate: () => userData.IsCompleted);

        if (userData != null)
        {
            DataSnapshot snapshot = userData.Result;

            foreach (DataSnapshot user in snapshot.Children)
            {
                IDictionary dictUser = (IDictionary)user.Value;
                if (dictUser["userID"].ToString() == _userID)
                {
                    onCallback.Invoke(true);
                    break;
                } else
                {
                    onCallback.Invoke(false);
                }
            }
        }
    }

    public void Authenticate()
    {
        StartCoroutine(IsUserInDB((bool userIsInDB) =>
        {
            if (userIsInDB)
            {
                _playContainer.SetActive(true);
                _authenticateContainer.SetActive(false);
                Debug.LogFormat("User authenticated: {0}", _userID);
            } else
            {
                _playContainer.SetActive(false);
                _authenticateContainer.SetActive(true);
                Debug.Log("Waiting for user to register...");
            }
        }));
    }
}
