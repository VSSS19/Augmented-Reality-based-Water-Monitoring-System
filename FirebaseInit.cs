using UnityEngine;
using Firebase;
using Firebase.Extensions;

public class FirebaseInit : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("✅ Firebase initialized successfully.");
            }
            else
            {
                Debug.LogError("❌ Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
}
