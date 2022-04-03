using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class InternetConnectionState : MonoBehaviour
{
    [SerializeField] private GameObject panelOffline;


    private void Start()
    {
        StartCoroutine(CheckInternetConnection((isConnected)=>{
            if (!isConnected)
            {
                panelOffline.SetActive(true);
            }
            else
            {
                panelOffline.SetActive(false);
            }
        }));
    }

    public static IEnumerator CheckInternetConnection(Action<bool> syncResult)
    {
        while (true)
        {
            
            const string echoServer = "http://google.com";

            bool result;
            using (var request = UnityWebRequest.Head(echoServer))
            {
                request.timeout = 5;
                yield return request.SendWebRequest();
                result = !request.isNetworkError && !request.isHttpError && request.responseCode == 200;
            }
            syncResult(result);
            yield return new WaitForSeconds(5);
        }
      
    }
}