using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    public abstract class BaseSkill : ScriptableObject
    {
        public new string name;
        public List<DamageTypes> types;
        public List<SpecialEffect> specialEffects;
        public Stats statUsed;

        public abstract void ActivateSkill(object target);
    }

}