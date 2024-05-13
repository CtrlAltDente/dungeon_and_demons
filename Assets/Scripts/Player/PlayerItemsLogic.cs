using DungeonAndDemons.Character;
using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Items;
using DungeonAndDemons.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Player
{
    public class PlayerItemsLogic : MonoBehaviour, IPlayerLogicPart
    {
        [SerializeField]
        private CharacterInventory _characterInventory;

        [SerializeField]
        private ItemObject _itemObjectPrefab;

        [SerializeField]
        private List<ItemObject> _availableItems;
        
        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.IsPickupItem)
            {
                PickupAvailableItem();
            }
        }

        public void PickupAvailableItem()
        {
            if (_availableItems.Count > 0)
            {
                ItemObject itemObject = _availableItems[0];
                ItemSlot slot = _characterInventory.GetSlotForItem(itemObject.Item);
                DropFromSlot(slot);
                _characterInventory.SetItem(itemObject.Item);
                RemoveItemFromItemList(itemObject);
                Destroy(itemObject.gameObject);
            }
        }

        public void DropFromSlot(ItemSlot slot)
        {
            DropItem(slot.Item);
            _characterInventory.SetItem(new Item(slot.ItemType, 0, null, null));
        }

        private void DropItem(Item item)
        {
            ItemObject spawnedObject = Instantiate(_itemObjectPrefab, transform.position + transform.forward * 1.5f + Vector3.up, Quaternion.identity, null);
            spawnedObject.Item = item;
        }

        private void OnTriggerEnter(Collider other)
        {
            AddItemToItemsList(GetItemInCollider(other));
        }

        private void OnTriggerExit(Collider other)
        {
            RemoveItemFromItemList(GetItemInCollider(other));
        }

        private ItemObject GetItemInCollider(Collider other)
        {
            return other.GetComponent<ItemObject>();
        }

        private void AddItemToItemsList(ItemObject itemObject)
        {
            if (itemObject)
            {
                if(!_availableItems.Contains(itemObject))
                {
                    itemObject.SetActiveUI(true);
                    _availableItems.Add(itemObject);
                }
            }
        }

        private void RemoveItemFromItemList(ItemObject itemObject)
        {
            if (itemObject)
            {
                if (_availableItems.Contains(itemObject))
                {
                    itemObject.SetActiveUI(false);
                    _availableItems.Remove(itemObject);
                }
            }
        }
    }
}