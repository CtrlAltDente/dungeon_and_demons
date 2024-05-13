using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    public class ItemUI : MonoBehaviour
    {
        private void Update()
        {
            UpdatePosition();
            UpdateRotation();
        }

        public void SetDescription(ItemObject itemObject)
        {

        }
        
        private void UpdatePosition()
        {
            transform.position = new Vector3(transform.parent.position.x, 3, transform.parent.position.z);
        }

        private void UpdateRotation()
        {
            transform.rotation = Quaternion.Euler(60f, 0f, 0f);
        }
    }
}