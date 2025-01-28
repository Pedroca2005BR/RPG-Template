using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "StatBuff", menuName = "Scriptable Objects/Special Effects/StatBuff")]
    public class StatBuff : SpecialEffect
    {
        public Stats statAffected;
        public float amount;
        public bool isMultiplier;
        public float duration;

        public override void ActivateEffect(object target, object checkCondition)
        {
            if (target.GetType() != typeof(Entity))
            {
                throw new System.Exception("Trying to use StatBuff on non entity!!!");
            }
            target = (Entity)target;

            if (hasCheckCondition)
            {
                
            }


        }
    }
}