using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "Scriptable Objects/Skills/Active Skill")]
    public class ActiveSkill : BaseSkill
    {
        public float baseDamage;
        public float cooldown;
        public float cost;


        public override void ActivateSkill(object target)
        {
            throw new System.NotImplementedException();
        }
    }

}