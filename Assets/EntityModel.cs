using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "NewEntityModel", menuName = "Scriptable Objects/EntityModel")]
    public class EntityModel : ScriptableObject
    {
        public new string name;

        [Header("Stats")]
        public List<float> statValues;

        [Header("Skills")]
        public List<PassiveSkill> passiveSkills;
        public List<ActiveSkill> activeSkills;

        [Header("Resistances")]
        public List<float> resistanceValues;
    }
}
