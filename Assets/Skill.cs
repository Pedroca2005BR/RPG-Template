using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
    public class Skill : ScriptableObject
    {
        public new string name;
        public float cost;
        public List<DamageTypes> types;
        public float baseDamage;
        public List<SpecialEffect> specialEffects;
        public bool isPassive;
        public TimeEvents timeOfActivation;

        public void ActivateSkill(object target)
        {

        }
    }

}