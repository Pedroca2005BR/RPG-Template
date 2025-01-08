using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    [CreateAssetMenu(fileName = "StatBuff", menuName = "Scriptable Objects/EntityModel")]
    public class EntityModel : ScriptableObject
    {
        public new string name;

        [Header("Stats")]
        public List<float> values;

        [Header("Skills")]
        public List<Skill> skills;
    }
}
