using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] GameObject _row, _content;

    DatabaseReference _dbReference;
    string _userID;

    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        CallMe();
    }

    void Update()
    {
        
    }

    IEnumerator GetScore()
    {
        var userData = _dbReference.Child("users").OrderByChild("userScore").GetValueAsync();
        yield return new WaitUntil(predicate: () => userData.IsCompleted);

        if (userData != null)
        {
            DataSnapshot snapshot = userData.Result;
            List<DataSnapshot> snapshotsList = new List<DataSnapshot>(snapshot.Children);

            var newRowPosX = _content.transform.position.x;
            var newRowPosY = _content.transform.position.y;
            var newRowPos = new Vector3(newRowPosX, newRowPosY, 0);
            var rank = 1;

            for (var i = snapshot.ChildrenCount - 1; i >= 0; i--)
            {
                Debug.Log( ((Dictionary<string, object>)snapshotsList[(int)i].Value)["userName"] + " - " + ((Dictionary<string, object>)snapshotsList[(int)i].Value)["userScore"]);

                var newRow = Instantiate(_row, newRowPos, _row.transform.rotation, _content.transform);
                newRowPos.y -= 20;

                newRow.name = _row.name + "-" + rank;

                var userRank = newRow.transform.GetChild(0).gameObject;
                userRank.GetComponent<TextMeshProUGUI>().text = rank + "";

                var userName = newRow.transform.GetChild(1).gameObject;
                userName.GetComponent<TextMeshProUGUI>().text = ((Dictionary<string, object>)snapshotsList[(int)i].Value)["userName"].ToString();

                var userScore = newRow.transform.GetChild(2).gameObject;
                userScore.GetComponent<TextMeshProUGUI>().text = ((Dictionary<string, object>)snapshotsList[(int)i].Value)["userScore"].ToString();

                rank++;
            }
        }
    }

    void CallMe()
    {
        /*User newUser = new User("test", "test", 2);
        string json = JsonUtility.ToJson(newUser);

        _dbReference.Child("users").Child("test").SetRawJsonValueAsync(json);*/

        StartCoroutine(GetScore());
    }
}
