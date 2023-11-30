using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemSlot : MonoBehaviour
    {
        public ItemType SlotType;
        public bool HasItem => _slotItemInfo.Type != ItemType.None;

        [SerializeField]
        private WorldItem _worldItemPrefab;

        [SerializeField]
        private WorldItem _slotWorldItem;
        [SerializeField]
        private ItemInfo _slotItemInfo;

        public void DropItem()
        {
            WorldItem worldItem = Instantiate(_worldItemPrefab, transform.forward + Vector3.up, Quaternion.identity, null);
            worldItem.ItemInfo = _slotItemInfo;
            worldItem.Initialize(false);

            if (_slotWorldItem != null)
            {
                Destroy(_slotWorldItem.gameObject);
            }

            _slotItemInfo = default;
        }

        public void SetItem(ItemInfo itemInfo)
        {
            _slotItemInfo = itemInfo;
            _slotWorldItem = Instantiate(_worldItemPrefab, transform.position, Quaternion.identity, transform);
            _slotWorldItem.ItemInfo = itemInfo;
            _slotWorldItem.Initialize(true);
        }
    }
}