using DungeonAndDemons.Character;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player.Items
{
    public class PlayerItemsPicker : MonoBehaviour
    {
        [SerializeField]
        private CharacterInventory _characterInventory;

        [SerializeField]
        private PlayerItemsDropper _playerItemsDropper;

        [SerializeField]
        private ItemObject _itemObjectPrefab;

        [SerializeField]
        private List<ItemObject> _availableItems;

        public void PickupAvailableItem()
        {
            if (_availableItems.Count > 0)
            {
                ItemObject itemObject = _availableItems[0];
                ItemSlot slot = _characterInventory.GetSlotForItem(itemObject.Item);
                _playerItemsDropper.DropFromSlot(slot);
                _characterInventory.SetItem(itemObject.Item);
                RemoveItemFromItemList(itemObject);
                Destroy(itemObject.gameObject);
            }
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
                if (!_availableItems.Contains(itemObject))
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