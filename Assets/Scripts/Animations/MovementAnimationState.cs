using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

namespace DungeonAndDemons.Animations
{
    public class MovementAnimationState : StateMachineBehaviour
    {
        public bool IsMove;
        public bool IsRoll;

        public void SetMovementState(bool value) => IsMove = value;
        public void SetRollState(bool value) => IsRoll = value;
    }
}