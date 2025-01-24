using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG_Template
{

    public abstract class SpecialEffect : ScriptableObject
    {
        public new string name;
        public SpecialEffectNeeds parameterNeeds;

        public abstract void ActivateEffect(object target);
    }

    public enum SpecialEffectNeeds
    {
        Entity,
        AttackInstance,
        BattleManager
    }

    public class NegateAttackException : Exception
    {
        public NegateAttackException(string message) : base(message) { }
    }
}