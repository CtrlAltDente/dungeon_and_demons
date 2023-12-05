using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Containers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Items
{
    public class ItemSlotVisualizer : MonoBehaviour
    {
        [SerializeField]
        private ItemType _slotType;
        [SerializeField]
        private ItemObject _itemObject;

        private Item CurrentItem;

        public void SetItemSlotInfo(ItemSlot itemSlot)
        {
            if (itemSlot.ItemType == _slotType)
            {
                if (CurrentItem != itemSlot.Item)
                {
                    VisualizeItemFromSlot(itemSlot);
                }
            }
        }

        private void VisualizeItemFromSlot(ItemSlot itemSlot)
        {
            _itemObject.Item = itemSlot.Item;
            _itemObject.Initialize();
        }
    }
}