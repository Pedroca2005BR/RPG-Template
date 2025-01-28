using UnityEngine;

namespace RPG_Template
{
    public abstract class BaseStateMachine
    {
        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();

    }
}