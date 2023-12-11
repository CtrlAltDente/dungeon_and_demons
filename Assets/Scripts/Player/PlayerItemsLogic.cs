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
                if(_availableItems.Count > 0)
                {
                    PickupItem(_availableItems[0].Item);
                    Destroy(_availableItems[0].gameObject);
                }
            }
        }

        public void PickupItem(Item item)
        {
            _characterInventory.SetItem(item);
        }

        public void DropFromSlot(int slotIndex)
        {
            DropItem(_characterInventory.Slots[slotIndex].Item);
            _characterInventory.SetItem(new Item(_characterInventory.Slots[slotIndex].ItemType, null, null));
        }

        public void DropItem(Item item)
        {
            if (item.Model != null)
            {
                ItemObject spawnedObject = Instantiate(_itemObjectPrefab, transform.position + transform.forward * 1.5f + Vector3.up, Quaternion.identity, null);
                spawnedObject.Item = item;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            AddItemToItemsList(other);
        }

        private void OnTriggerExit(Collider other)
        {
            RemoveItemFromItemList(other);
        }

        private void AddItemToItemsList(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

            if (itemObject)
            {
                if(!_availableItems.Contains(itemObject))
                {
                    itemObject.SetActiveUI(true);
                    _availableItems.Add(itemObject);
                }
            }
        }

        private void RemoveItemFromItemList(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

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