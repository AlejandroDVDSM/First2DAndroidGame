using UnityEngine;
using Firebase;
using Firebase.Auth;

public class FirebaseManager : MonoBehaviour
{
    FirebaseApp _app;

    /*[SerializeField] TriggerPlayContainer _triggerPlayContainer;
    [SerializeField] AuthUI _authUI;
    [SerializeField] GameObject _playContainer;*/
    bool _isUserAuthenticated = false;

    public bool IsUserAuthenticated { get => _isUserAuthenticated; }

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                _app = FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Login();
            }
            else
            {
                Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    void Login()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        if (IsUserLoggedIn())
        {
            Debug.Log("{ " + auth.CurrentUser.UserId + " } user is already authenticated");
            return;
        }

        auth.SignInAnonymouslyAsync().ContinueWith(task => {
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
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    bool IsUserLoggedIn()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null)
        {
            _isUserAuthenticated = true;
            return true;
        }

        _isUserAuthenticated = false;
        return false;
    }
}
