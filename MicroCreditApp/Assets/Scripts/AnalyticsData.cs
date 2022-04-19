using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsData : MonoBehaviour
{
   
   private void Start()
    {
     AnalyticsResult result =   Analytics.CustomEvent("Start");
     Analytics.FlushEvents();
     Debug.Log(result + "CustomEvent");
    }

    public void OpenWebView()
    {
        Analytics.CustomEvent("Opened WebView", new Dictionary<string, object>
        {
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }

    public void CloseWebview()
    {
        Analytics.CustomEvent("Close Vebwiew", new Dictionary<string, object>
        {
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }

    public void BookWasOpened()
    {
        Analytics.CustomEvent("Close Vebwiew", new Dictionary<string, object>
        {
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }


}
