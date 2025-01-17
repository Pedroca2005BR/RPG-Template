using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "NewEntityModel", menuName = "Scriptable Objects/EntityModel")]
    public class EntityModel : ScriptableObject
    {
        public new string name;

        [Header("Stats")]
        public List<float> values;

        [Header("Skills")]
        public List<PassiveSkill> passiveSkills;
        public List<ActiveSkill> activeSkills;
    }
}
