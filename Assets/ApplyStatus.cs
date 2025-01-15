using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "NewApplyStatus", menuName = "Scriptable Objects/Special Effects/ApplyStatus")]
    public class ApplyStatus : SpecialEffect
    {
        // Apply Status is used as an Special Effect to apply a status effect on a target

        public override void ActivateEffect(object target)
        {
            throw new System.NotImplementedException();
        }
    }

}