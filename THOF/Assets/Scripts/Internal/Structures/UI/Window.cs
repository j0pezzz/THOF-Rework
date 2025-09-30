using System;
using TMPro;
using UnityEngine;

namespace Internal.Structures.UI
{
    [Serializable]
    public class Window
    {
        public string WindowName;
        public GameObject WindowRoot;
        public TextMeshProUGUI Description;
    }
}