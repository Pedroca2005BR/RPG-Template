using UnityEngine;

namespace RPG_Template
{
    public abstract class BasePointSystem
    {
        public float maxPoints {  get; private set; }
        public float currentPoints {  get; private set; }

        public void ChangeCurrentPoints(float currentPoints)
        {
            this.currentPoints = currentPoints;
        }

        public void ChangeMaxPoints(float maxPoints)
        {
            this.maxPoints = maxPoints;
        }
    }

}