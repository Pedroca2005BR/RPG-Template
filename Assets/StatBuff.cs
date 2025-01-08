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

        public override void ActivateEffect(List<object> targets)
        {
            throw new System.NotImplementedException();
        }
    }
}