using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Containers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Items
{
    public abstract class ItemSlotVisualizer : MonoBehaviour
    {
        protected abstract ItemType SlotType { get; }

        public void SetItemSlotInfo(ItemSlot itemSlot)
        {
            if (itemSlot.ItemType == SlotType)
            {
                SetItem(itemSlot.ItemIndex);
            }
        }

        public void DropItem()
        {

        }

        private void SetItem(int itemIndex)
        {

        }
    }
}