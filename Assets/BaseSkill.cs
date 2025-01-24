using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    public abstract class BaseSkill : ScriptableObject
    {
        public new string name;
        public List<SpecialEffect> specialEffects;

        public PossibleTargets possibleTargets;
        public NumberOfTargets numberOfTargets;

        //public abstract void ActivateSkill(object target);
    }

}