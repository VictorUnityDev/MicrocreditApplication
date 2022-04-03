using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     AnalyticsResult result =   Analytics.CustomEvent("Start");
     Analytics.FlushEvents();
     Debug.Log(result + "CustomEvent");
    }

    public void OpenWebView()
    {
        Analytics.CustomEvent("Opened WebView", new Dictionary<string, object>
        {
            { "name",  name},
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }


}
