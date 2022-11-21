using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
using System;
using Firebase.Extensions;

public class FirebaseDB : MonoBehaviour
{
    [SerializeField] TMP_InputField _userName;
    /*[SerializeField] AuthUI _authUI;
    [SerializeField] TriggerPlayContainer _triggerPlayContainer;*/
    [SerializeField] GameObject _playContainer, _authenticateContainer;

    DatabaseReference _dbReference;
    string _userID;
    bool _userIsRegistered;

    public string UserID { get => _userID; }

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
    }

   /* public void IsUserRegisteredInDB()
    {

        FirebaseDatabase.DefaultInstance
          .GetReference("users")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.LogError("GetUserID encountered an error: " + task.Exception);
                  return;
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;
                  // Do something with snapshot...
                  foreach (DataSnapshot user in snapshot.Children)
                  {
                      IDictionary dictUser = (IDictionary)user.Value;
                      if (dictUser["userID"].ToString() == _userID)
                      {
                          Debug.Log(dictUser["userID"] + " - V");

                          break;
                      } else
                      {
                          Debug.Log(dictUser["userID"] + " - F");
                      }

                      //Debug.Log("" + dictUser["userID"] /*+ " - " + dictUser["userName"] + " - " + dictUser["userScore"]);
                  }
              }
        });
    }*/

    IEnumerator GetUserIDCoroutine(Action<bool> onCallback)
    {
        /*var userIDData = _dbReference.Child("users").Child(_userID).Child("userID").GetValueAsync();

        yield return new WaitUntil(predicate: () => userIDData.IsCompleted);

        if (userIDData != null)
        {
            DataSnapshot snapshot = userIDData.Result;

            onCallback.Invoke(snapshot.Value.ToString());
        }*/

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

    public void HideAuthUI()
    {
        StartCoroutine(GetUserIDCoroutine((bool id) =>
        {
            if (id)
            {
                _playContainer.SetActive(true);
            } else
            {
                _authenticateContainer.SetActive(true);
            }
        }));
    }

}
