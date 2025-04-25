using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class WaterLevelController : MonoBehaviour
{
    public GameObject waterObject;  // Assign the Water object (cylinder) in Unity Inspector
    private float maxWaterHeight = 2.5f;  // Max scale.y for full tank
    private float minWaterHeight = 0.1f;  // Min scale.y when empty

    private DatabaseReference databaseReference;

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                ReadWaterLevel();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies.");
            }
        });
    }

    void ReadWaterLevel()
    {
        // ✅ Updated path to match your Firebase: ultrasonic/distance
        databaseReference.Child("ultrasonic").Child("distance").ValueChanged += (sender, args) =>
        {
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }

            if (args.Snapshot.Exists)
            {
                float distance = float.Parse(args.Snapshot.Value.ToString());

                // Optional: Map distance (0–400) to water level (inverted logic if needed)
                float waterPercent = Mathf.Clamp01((400f - distance) / 400f) * 100f;

                UpdateWaterHeight(waterPercent);
            }
        };
    }

    void UpdateWaterHeight(float level)
    {
        // Normalize height based on level (0 to 100%)
        float normalizedHeight = Mathf.Lerp(minWaterHeight, maxWaterHeight, level / 100f);

        // Set scale
        Vector3 newScale = waterObject.transform.localScale;
        newScale.y = normalizedHeight;
        waterObject.transform.localScale = newScale;

        // Adjust position so water grows from bottom
        Vector3 newPos = waterObject.transform.localPosition;
        newPos.y = normalizedHeight / 2f;
        waterObject.transform.localPosition = newPos;

        Debug.Log("Water Level Updated: " + level + "%");
    }
}
