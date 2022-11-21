using UnityEngine;
using Firebase.Auth;

public class FirebaseAuthentication : MonoBehaviour
{
    FirebaseAuth _auth;

    // Start is called before the first frame update
    void Start()
    {
        _auth = FirebaseAuth.DefaultInstance;
    }

    void AuthenticateUser()
    {
        _auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} { {1} }",
                newUser.DisplayName, newUser.UserId);
        });
    }
}
