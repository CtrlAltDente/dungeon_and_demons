using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Items
{
    public class ItemSlot : MonoBehaviour
    {
        public ItemType SlotItemType;

        public UnityEvent<ItemType, int> OnItemInformationUpdated;

        public ItemsContainer[] ItemsContainers;

        private ItemWorldObject _slotItemWorldObject;

        public void PickupItem(ItemWorldObject itemObject)
        {
            DropItem();

            if (itemObject.ItemType == SlotItemType)
            {
                ItemsContainer itemsContainer = GetItemsContainerByType(itemObject.ItemType);

                _slotItemWorldObject = itemObject;

                _slotItemWorldObject.IsKinematic = true;
                _slotItemWorldObject.transform.position = transform.position + itemsContainer.Items[_slotItemWorldObject.ItemIndex].Model.PositionOffset;
                _slotItemWorldObject.transform.rotation = transform.rotation * Quaternion.Euler(itemsContainer.Items[_slotItemWorldObject.ItemIndex].Model.RotationOffset);
                
                OnItemInformationUpdated?.Invoke(SlotItemType, _slotItemWorldObject.ItemIndex);
            }
        }

        public void DropItem()
        {
            if(_slotItemWorldObject != null )
            {
                _slotItemWorldObject.IsKinematic = false;
                _slotItemWorldObject.transform.position = transform.forward + Vector3.up;
                _slotItemWorldObject.transform.rotation = Quaternion.identity;
                
                _slotItemWorldObject = null;

                OnItemInformationUpdated?.Invoke(SlotItemType, 0);
            }
        }

        private ItemsContainer GetItemsContainerByType(ItemType itemType)
        {
            foreach (var item in ItemsContainers)
            {
                if (item.ContainerItemsType == itemType)
                {
                    return item;
                }
            }

            return null;
        }
    }
}