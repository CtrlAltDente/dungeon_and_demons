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

        public UnityEvent<ItemType, ItemStats> OnItemInformationUpdated;

        private ItemWorldObject _slotItemWorldObject;

        public void PickupItem(ItemWorldObject itemObject)
        {
            DropItem();

            if (itemObject.ItemReference.Type == SlotItemType)
            {
                _slotItemWorldObject = itemObject;

                _slotItemWorldObject.IsKinematic = true;
                _slotItemWorldObject.transform.position = transform.position + _slotItemWorldObject.ItemReference.Model.PositionOffset;
                _slotItemWorldObject.transform.rotation = transform.rotation * Quaternion.Euler(_slotItemWorldObject.ItemReference.Model.RotationOffset);
                
                OnItemInformationUpdated?.Invoke(SlotItemType, _slotItemWorldObject.ItemReference.Stats);
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

                OnItemInformationUpdated?.Invoke(SlotItemType, new ItemStats(1));
            }
        }
    }
}