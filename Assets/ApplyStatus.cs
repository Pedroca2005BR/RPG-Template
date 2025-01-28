using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "NewApplyStatus", menuName = "Scriptable Objects/Special Effects/Apply Status")]
    public class ApplyStatus : SpecialEffect
    {
        // Apply Status is used as an Special Effect to apply a status effect on a target
        public StatusCondition condition;
        public float chance; // from 1 to 100

        public override void ActivateEffect(object target, object checkCondition)
        {
            throw new System.NotImplementedException();
        }
    }

}