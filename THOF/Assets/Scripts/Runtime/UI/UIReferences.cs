using System.Collections;
using System.Collections.Generic;
using Internal.Structures.UI;
using TMPro;
using UnityEngine;

public class UIReferences : MonoBehaviour
{
    [SerializeField] private List<Window> windows;
    [SerializeField] private TextMeshProUGUI shopText;

    public void OpenWindow(string windowName, string text = "", float closeTime = 0)
    {
        Window window = windows.Find(x => x.WindowName == windowName);

        if (window == null)
        {
            Debug.LogWarning($"No window found with name <b>{windowName}<b>");
            return;
        }

        if (!string.IsNullOrEmpty(text) && window.Description)
        {
            window.Description.SetText(text);
        }
        
        window.WindowRoot.SetActive(true);
        StartCoroutine(WaitClose(window, closeTime));
    }

    public void ActivateOpenShop()
    {
        shopText.gameObject.SetActive(true);

        shopText.SetText("Press E to Open Shop");
    }

    public void ActivateCloseShop(bool overrideClose = false)
    {
        if (overrideClose)
        {
            shopText.gameObject.SetActive(false);
        }
        
        shopText.SetText("Press E to Close Shop");
    }

    IEnumerator WaitClose(Window window, float time = 0)
    {
        if (time > 0) yield return new WaitForSeconds(time);
        
        window.WindowRoot.SetActive(false);
    }

    static UIReferences _instance;

    public static UIReferences Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<UIReferences>();
            return _instance;
        }
    }
}
