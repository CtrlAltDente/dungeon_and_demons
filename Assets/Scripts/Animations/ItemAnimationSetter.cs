using DungeonAndDemons.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Animations
{
    public class ItemAnimationSetter : MonoBehaviour
    {
        private const string IDLE_ANIMATION = "ANIMATION_IDLE";

        private string ATTACK_ANIMATION => _characterItems.Slots[0].Item.ModelIndex.ToString();
        
        [SerializeField]
        private CharacterItems _characterItems;
        
        [SerializeField]
        private AnimatorOverrideController _animatorOverrideController;

        [SerializeField]
        private Animator _animator;

        private void Start()
        {
            
        }

        private void UpdateAnimations()
        {

        }
    }
}