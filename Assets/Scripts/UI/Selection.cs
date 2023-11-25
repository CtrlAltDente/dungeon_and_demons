using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    [Serializable]
    public struct Selection
    {
        public Sprite Sprite;
        public int Value;

        public Selection(Sprite sprite, int value)
        {
            Sprite = sprite;
            Value = value;
        }
    }
}