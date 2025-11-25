using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] AudioSource aSource;

    bool _isPaused;

    void Awake()
    {
        if (!_isPaused)
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        
        content.SetActive(_isPaused);
        aSource.mute = _isPaused;
        Time.timeScale = _isPaused ? 0 : 1;
    }

    public void GoToMainMenu()
    {
        if (Stats.Instance != null)
        {
            SaveSystem.SaveGame(Stats.Instance);
        }
        
        SceneManager.LoadScene(0);
    }
}
