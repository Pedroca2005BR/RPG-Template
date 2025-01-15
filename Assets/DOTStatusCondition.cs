using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "DOTStatusCondition", menuName = "Scriptable Objects/Status Condition/DOTStatusCondition")]
    public class DOTStatusCondition : StatusCondition
    {
        public float damageAmount;
        

        public override void ActivateEffect(object target)
        {
            throw new System.NotImplementedException();
        }
    }
}
