using DungeonAndDemons.Enums;
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
        private SlotType _slotType;
        [SerializeField]
        private ItemObject _itemObject;

        public void SetItemSlotInfo(ItemSlot itemSlot)
        {
            if (itemSlot.Type == _slotType)
            {
                VisualizeItemFromSlot(itemSlot);
            }
        }

        private void VisualizeItemFromSlot(ItemSlot itemSlot)
        {
            Debug.Log("Visualize");
            _itemObject.Item = itemSlot.Item;
            _itemObject.Initialize();
        }
    }
}