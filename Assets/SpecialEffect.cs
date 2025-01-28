using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG_Template
{

    public abstract class SpecialEffect : ScriptableObject
    {
        public new string name;
        public SpecialEffectNeeds parameterNeeds;

        public bool hasCheckCondition;
        public SpecialEffectNeeds checkCondition;

        public abstract void ActivateEffect(object target, object checkCondition);
    }

    public enum SpecialEffectNeeds
    {
        Attacker,
        Target,
        AttackInstance,
        BattleManager
    }

    public class NegateAttackException : Exception
    {
        public NegateAttackException(string message) : base(message) { }
    }
}