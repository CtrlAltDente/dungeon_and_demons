using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects.Containers;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Items
{
    public abstract class ItemSlotVisualizer<T> : MonoBehaviour
    {
        [SerializeField]
        private Container<T> ItemsContainer;
        protected abstract ItemType SlotType { get; }

        public abstract void SetItemSlotInfo(ItemSlot itemSlot);
        public abstract void SetItemObject(ItemObject<IItemPreferences> itemObject);
        public abstract void DropItem();
    }
}