using UnityEngine;

namespace RPG_Template
{
    public enum PossibleTargets
    {
        Caster,
        AlliesExceptCaster,
        Allies,
        Enemies,
        Everyone,
        EveryoneElse
    }

    public enum NumberOfTargets
    {
        One,
        Two,
        Three,
        All
    }
}