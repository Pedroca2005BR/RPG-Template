using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "Scriptable Objects/Skills/Active Skill")]
    public class ActiveSkill : BaseSkill
    {
        public List<DamageTypes> types;
        public Stats statUsed;
        public Stats statDefenderUses;

        public float baseDamage;
        public float cooldown;
        public float cost;


        //public override void ActivateSkill(object target)
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}