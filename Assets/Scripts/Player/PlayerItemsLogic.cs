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
        private ItemUI _itemUiPrefab;
        [SerializeField]
        private List<ItemUI> _itemUiElements;

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            if (playerInputData.ScrollValue < 0)
            {
                DropFromSlot(2);
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
            ShowItemUI(other);
        }

        private void OnTriggerExit(Collider other)
        {
            HideItemUI(other);
        }

        private void ShowItemUI(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

            if (itemObject)
            {
                ItemUI newItemUi = Instantiate(_itemUiPrefab, itemObject.transform.position, Quaternion.identity, null);
                newItemUi.ItemObject = itemObject;

                newItemUi.Button.onClick.AddListener(() =>
                {
                    PickupItem(itemObject.Item);
                    _itemUiElements.Remove(newItemUi);
                    Destroy(newItemUi.gameObject);
                    Destroy(itemObject.gameObject);
                });

                _itemUiElements.Add(newItemUi);
            }
        }

        private void HideItemUI(Collider other)
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();

            ItemUI itemUIObject = null;

            if (itemObject)
            {
                foreach (ItemUI itemUI in _itemUiElements)
                {
                    if (itemUI.ItemObject == itemObject)
                    {
                        itemUIObject = itemUI;
                        break;
                    }
                }
            }

            if (itemUIObject)
            {
                _itemUiElements.Remove(itemUIObject);
                Destroy(itemUIObject.gameObject);
            }
        }
    }
}