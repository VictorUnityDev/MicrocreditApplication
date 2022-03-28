using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensScene : MonoBehaviour
{
    [SerializeField] private List<GameScreen> _screensForFirstStart;

    [SerializeField] private GameObject rulesPanel;
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private GameObject lineMenu;
    
    [SerializeField] SaveManager _saveManager;

    private int _currentIndex;

  private void Start()
    {
       
        if (_saveManager.IsFirstEnter)
        {
            OpenFirstScreen();
        }
        else
        {
            OpenMainScreen();
        }
    }

    private void OpenMainScreen()
    {
        mainScreenPanel.gameObject.SetActive(true);
        lineMenu.gameObject.SetActive(true);
    }

    private void OpenFirstScreen()
    {
        rulesPanel.gameObject.SetActive(true);
        _currentIndex = _screensForFirstStart[0].index;
        OpenScreenNext(_screensForFirstStart[0]);
    }

    public void OnNext()
    {
        for (int i = 0; i < _screensForFirstStart.Count; i++)
        {
            if (i == _currentIndex + 1)
            {
                HideScreenPrevious(_screensForFirstStart[i-1]);
                OpenScreenNext(_screensForFirstStart[i]);
                _currentIndex = _screensForFirstStart[i].index;
                break;
            }
        }
    }

    private void OpenScreenNext(GameScreen screen)
    {
        screen.gameObject.SetActive(true);
    } 
    private void HideScreenPrevious(GameScreen screen)
    {
        screen.gameObject.SetActive(false);
    }
}