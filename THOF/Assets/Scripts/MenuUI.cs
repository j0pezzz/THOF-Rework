using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] string FirstWindow = "Menu";
    [SerializeField] List<UIWindow> windows;

    [SerializeField] Button continueBtn;

    UIWindow _openWindow;

    void Awake()
    {
        Application.targetFrameRate = 60; // Set the FPS to 60 to avoid using too much resources.
        OpenWindow(FirstWindow);
        continueBtn.interactable = SaveSystem.LoadPlayer();
    }

    public void ProceedToGame() => SceneManager.LoadScene(1);

    public void OpenWindow(string windowName)
    {
        UIWindow window = windows.Find(x => x.name == windowName);

        if (window == null)
        {
            Debug.LogWarning($"Window {windowName} not found.");
            return;
        }
        
        // If we have a window already open, close that window.
        if (_openWindow != null) _openWindow.ui.SetActive(false);
        
        window.ui.SetActive(true);
        _openWindow = window;
    }

    public void QuitGame() => Application.Quit();
}

[Serializable]
public class UIWindow
{
    public string name;
    public GameObject ui;
}
