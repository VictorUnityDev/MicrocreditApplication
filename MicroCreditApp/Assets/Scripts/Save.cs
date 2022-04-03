using System;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField] private bool ClearPrefs;
    private int _countSessions;
    private const string SESSIONS = "sessions";

    public static event Action<bool> OnFirstEnter;

    private int count;

    private void OnEnable()
    {
        CheckSession();

        if (count != 1 )
        {
            OnFirstEnter?.Invoke(false);
        }
        else
        {
            OnFirstEnter?.Invoke(true);
        }
    }

    private void Start()
    {
        CheckSession();
    }

    private void CheckSession()
    {
        count = LoadData(SESSIONS, _countSessions);
        count += 1;
        var currentCount = count;
        Debug.Log(currentCount);
        SaveData(SESSIONS, currentCount);
    }

    private void SaveData(string str, int count)
    {
        PlayerPrefs.SetInt(str, count);
        Debug.Log("Save" + count);
        PlayerPrefs.Save();
    }

    private int LoadData(string str, int count)
    {
        var number = PlayerPrefs.GetInt(str, count);
        Debug.Log("Load" + number);
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