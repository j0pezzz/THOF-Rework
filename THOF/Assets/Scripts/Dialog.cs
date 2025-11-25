using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Image enemyIcon;

    string _talking;

    public GameObject logPanel;
    public Text speech;

    public void StartDialog()
    {
        logPanel.SetActive(true);
    }

    public void Leave()
    {
        logPanel.SetActive(false);
        PlayerController.Instance.inAction = false;
    }

    public void SetEnemyIcon(Sprite sprite)
    {
        enemyIcon.sprite = sprite;
    }

    public void Fight() => Battle.Instance.Begin();

    public void TalkShit()
    {
        speech.text = _talking;
    }

    private static Dialog _instance;
    public static Dialog Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<Dialog>();
            return _instance;
        }
    }
}
