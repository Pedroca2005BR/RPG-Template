using UnityEngine;



namespace RPG_Template
{
    public abstract class StatusCondition : ScriptableObject
    {
        public new string name;
        public float duration;

        public abstract void ActivateEffect(object target);
    }
}
