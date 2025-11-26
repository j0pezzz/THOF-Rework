using Internal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Image enemyIcon;
    [SerializeField] private TextMeshProUGUI enemyTalk;

    public GameObject logPanel;

    public void StartDialog()
    {
        enemyTalk.SetText(GameTexts.Dialog[Random.Range(0, GameTexts.Dialog.Length)]);
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

    public void Fight()
    {
        logPanel.SetActive(false);
        Battle.Instance.Begin();
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
