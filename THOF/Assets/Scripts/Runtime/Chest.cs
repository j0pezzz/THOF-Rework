using System;
using System.Collections.Generic;
using UnityEngine;
using EventHandler = Internal.EventHandler;

namespace Runtime
{
    public class Chest : MonoBehaviour
    {
        public List<ChestItem> chestItems;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            ChestUI.Instance.InitializeChestItems(chestItems);
            UIReferences.Instance.ShowInteract(true);
            EventHandler.Player.DispatchPlayerEnterChest(true);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            UIReferences.Instance.ShowInteract(false);
            EventHandler.Player.DispatchPlayerEnterChest(false);
        }
    }
}