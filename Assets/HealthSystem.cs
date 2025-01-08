using UnityEngine;

namespace RPG_Template
{
    public class HealthSystem : BasePointSystem
    {
        public void Heal(float amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }
            else if (currentPoints + amount >= maxPoints)
            {
                ChangeCurrentPoints(maxPoints);
            }
            else
            {
                ChangeCurrentPoints(currentPoints + amount);
            }
        }

        public void Damage(float amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }
            else if (currentPoints - amount <= 0)
            {
                ChangeCurrentPoints(0);
                // Die...
            }
            else
            {
                ChangeCurrentPoints(currentPoints - amount);
            }
        }
    }
}
