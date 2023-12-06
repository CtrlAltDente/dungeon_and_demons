using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    public class ItemUI : MonoBehaviour
    {
        public ItemObject ItemObject;

        public Button Button => _button;

        [SerializeField]
        private Button _button;
    }
}