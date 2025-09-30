using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public AudioSource mSource;

    bool _isPaused;

    void Awake()
    {
        if (!_isPaused)
        {
            Time.timeScale = 1f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }

    public void Paused()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            mSource.mute = true;
            Time.timeScale = 0f;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            mSource.mute = false;
            Time.timeScale = 1f;
        }
    }

    public void GoMenu() => SceneManager.LoadScene(0);
    
    static Pause _instance;

    public static Pause Instance
    {
        get
        {
            if (_instance == null) _instance = FindAnyObjectByType<Pause>();
            return _instance;
        }
    }
}
