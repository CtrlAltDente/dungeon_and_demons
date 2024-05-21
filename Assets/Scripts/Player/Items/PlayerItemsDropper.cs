using DungeonAndDemons.Character;
using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player.Items
{
    public class PlayerItemsDropper : MonoBehaviour
    {
        [SerializeField]
        private CharacterInventory _characterInventory;

        [SerializeField]
        private ItemObject _itemObjectPrefab;

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
    }
}