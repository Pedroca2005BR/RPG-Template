using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "DOTStatusCondition", menuName = "Scriptable Objects/Status Condition/DOT Status Condition")]
    public class DOTStatusCondition : StatusCondition
    {
        public float damageAmount;
        

        public override void ActivateEffect(object target)
        {
            base.ActivateEffect(target);

            throw new System.NotImplementedException();
        }
    }
}
