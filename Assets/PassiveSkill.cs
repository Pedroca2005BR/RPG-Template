using UnityEngine;
using System.Collections.Generic;


namespace RPG_Template
{

    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "Scriptable Objects/Skills/Passive Skill")]
    public class PassiveSkill : BaseSkill
    {
        public List<GlobalEvents> triggers;

        //public override void ActivateSkill(object target)
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}
