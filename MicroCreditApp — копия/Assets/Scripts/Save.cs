using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField] private bool ClearPrefs;
    private int _countSessions = 0;
    private const string SESSIONS = "sessions";

    public static event Action<bool> OnFirstEnter;

    private int count;

    private void Awake()
    {
        CheckSession();

        if (count != 1)
        {
            OnFirstEnter?.Invoke(false);
        }
        else
        {
            OnFirstEnter?.Invoke(true);
        }
    }

    private void CheckSession()
    {
        count = LoadData(SESSIONS, _countSessions);
        Debug.Log(count);
        count += 1;
        SaveData(SESSIONS, count);
    }

    private void SaveData(string str, int count)
    {
        PlayerPrefs.SetInt(str, count);
        PlayerPrefs.Save();
    }

    private int LoadData(string str, int count)
    {
        var number = PlayerPrefs.GetInt(str, count);
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