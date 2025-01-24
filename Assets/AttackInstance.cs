using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    public class AttackInstance
    {
        public float damage;
        public List<DamageTypes> damageTypes;
        public List<SpecialEffect> specialEffects;

        public AttackInstance(ActiveSkill skill)
        {
            // base damage calculations here
            damage = skill.baseDamage;
            damageTypes = skill.types;
            specialEffects = skill.specialEffects;
        }

        public AttackInstance(AttackInstance attack)
        {
            damage = attack.damage;
            damageTypes = attack.damageTypes;
            specialEffects = attack.specialEffects;
        }
    }
}
