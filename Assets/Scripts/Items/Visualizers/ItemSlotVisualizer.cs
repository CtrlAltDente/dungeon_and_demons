using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Containers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Items
{
    public abstract class ItemSlotVisualizer<T> : MonoBehaviour where T : IItemPreferences
    {
        [SerializeField]
        private Container<T> ItemsContainer;
        [SerializeField]
        private ItemObject<T> ItemObject;

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
            ItemObject<T> itemObject = Instantiate(ItemObject, transform.forward * 1.5f + Vector3.up, Quaternion.identity, null);
            itemObject.IsKinematic = true;
        }

        private void SetItem(int itemIndex)
        {
            ItemObject.Item = ItemsContainer.Items[itemIndex];
            ItemObject.Initialize();
        }
    }
}