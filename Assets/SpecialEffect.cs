using System.Collections.Generic;
using UnityEngine;

namespace RPG_Template
{

    public abstract class SpecialEffect : ScriptableObject
    {
        public new string name;

        public abstract void ActivateEffect(List<object> targets);
    }

}