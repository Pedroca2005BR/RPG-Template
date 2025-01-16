using UnityEngine;



namespace RPG_Template
{
    [CreateAssetMenu(fileName = "StatusCondition", menuName = "Scriptable Objects/Status Condition/Buff Status Condition")]
    public class StatusCondition : ScriptableObject
    {
        public new string name;
        public float duration;
        public StatBuff buff;   // can be null

        public virtual void ActivateEffect(object target)
        {
            throw new System.NotImplementedException();
        }
    }
}
