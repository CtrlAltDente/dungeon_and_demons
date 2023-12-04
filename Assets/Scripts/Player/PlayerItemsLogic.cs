using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour, IPlayerLogicPart
    {
        public UnityEvent<IItemObject<IItemBase>> OnItemPicked;

        private List<IItemObject<IItemBase>> AvailableItems = new List<IItemObject<IItemBase>>();

        [SerializeField]
        private List<GameObject> gameObjects = new List<GameObject>();

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.ScrollValue > 0)
            {
                PickupItem();
            }
        }

        private void PickupItem()
        {
            if (AvailableItems.Count > 0)
            {
                OnItemPicked?.Invoke(AvailableItems[0]);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            AddPossibleItems(other);
            Debug.Log($"Added. Items: {AvailableItems.Count}");
        }

        private void OnTriggerExit(Collider other)
        {
            RemovePossibleItems(other);
            Debug.Log($"Removed. Items: {AvailableItems.Count}");
        }

        private void AddPossibleItems(Collider other)
        {
            if (AddItem(other.GetComponent<AccessoryObject>()))
                gameObjects.Add(other.gameObject);
            if (AddItem(other.GetComponent<SuitObject>()))
                gameObjects.Add(other.gameObject);
            if (AddItem(other.GetComponent<WeaponObject>()))
                gameObjects.Add(other.gameObject);
        }

        private void RemovePossibleItems(Collider other)
        {
            if (RemoveItem(other.GetComponent<AccessoryObject>()))
                gameObjects.Remove(other.gameObject);
            if (RemoveItem(other.GetComponent<SuitObject>()))
                gameObjects.Remove(other.gameObject);
            if (RemoveItem(other.GetComponent<WeaponObject>()))
                gameObjects.Remove(other.gameObject);
        }

        private bool AddItem(IItemObject<IItemBase> itemObject)
        {
            if (itemObject == null || AvailableItems.Contains(itemObject))
                return false;

            AvailableItems.Add(itemObject);

            return true;
        }

        private bool RemoveItem(IItemObject<IItemBase> itemObject)
        {
            if (itemObject == null || !AvailableItems.Contains(itemObject))
                return false;

            AvailableItems.Remove(itemObject);

            return true;
        }
    }
}