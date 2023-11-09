using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Animations
{
    public class ModelAnimations : MonoBehaviour
    {
        public AttackAnimationConfig[] AttackAnimations;

        public AttackAnimationConfig RandomAttackAnimation => AttackAnimations[Random.Range(0, AttackAnimations.Length)];
    }
}