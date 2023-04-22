using OneSignalSDK;
using UnityEngine;

public class OneSignalInitializer : MonoBehaviour
{

    private void Start()
    {
        // Enable lines below to debug issues with OneSignal
        OneSignal.Default.LogLevel = LogLevel.Info;
        OneSignal.Default.AlertLevel = LogLevel.Fatal;

        OneSignal.Default.Initialize("77b9f0ad-aeb5-40c2-a191-d3833df46e4d");
    }
}