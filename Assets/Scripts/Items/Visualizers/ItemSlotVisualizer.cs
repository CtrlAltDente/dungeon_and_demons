using UnityEngine;

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
            if (itemSlot.ItemType == _slotType)
            {
                VisualizeItemFromSlot(itemSlot);
            }
        }

        private void VisualizeItemFromSlot(ItemSlot itemSlot)
        {
            Debug.Log("Visualize");
            _itemObject.Item = itemSlot.Item;
            _itemObject.Initialize(Vector3.zero, Vector3.zero);
        }
    }
}