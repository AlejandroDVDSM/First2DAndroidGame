using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class UpdateFirebaseDatabase : MonoBehaviour
{
    DatabaseReference _dbReference;
    string _userID;

    [SerializeField] ScoreManager _scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void UpdateScore()
    {
        _dbReference.Child("users").Child(_userID).Child("userScore").SetValueAsync(_scoreManager.Score);
    }
}
