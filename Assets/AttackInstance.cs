using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    // AttackInstance is a class that contains information about the attack that is happening.
    // it has the damage it will cause, the Type of damage, the stats used and the special effects it will apply.
    public class AttackInstance
    {
        public float damage;
        public List<DamageTypes> damageTypes;
        public Stats statAttackerUsed;
        public Stats statDefenderUsed;
        public List<SpecialEffect> specialEffects;

        public AttackInstance(ActiveSkill skill)
        {
            damage = skill.baseDamage;
            damageTypes = skill.types;
            specialEffects = skill.specialEffects;
            statAttackerUsed = skill.statUsed;
            statDefenderUsed = skill.statDefenderUses;
        }

        public AttackInstance(AttackInstance attack)
        {
            damage = attack.damage;
            damageTypes = attack.damageTypes;
            specialEffects = attack.specialEffects;
            statDefenderUsed = attack.statDefenderUsed;
            statAttackerUsed = attack.statAttackerUsed;
        }
    }
}
