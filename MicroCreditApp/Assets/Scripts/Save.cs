using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField] private bool ClearPrefs;
    private int _countSessions;
    private const string SESSIONS = "sessions";

    private int count;

    void Start()
    {
        CheckSession();

        if (count == 1)
        {
            Debug.Log("is  first");
        }
        else
        {
            Debug.Log("is not first");
        }
    }

    private void CheckSession()
    {
        count = LoadData(SESSIONS, _countSessions);
        count += 1;
        SaveData(SESSIONS, count);
     
    }

    private void SaveData(string str,int count)
    {
        PlayerPrefs.SetInt(str,count);
        PlayerPrefs.Save();
    }

    private int LoadData(string str, int count)
    {
      var number =  PlayerPrefs.GetInt(str, count);
      return number;
    }

     private void OnDestroy()
    {
        if (ClearPrefs)
        {
            PlayerPrefs.DeleteAll();
        }

     }
}