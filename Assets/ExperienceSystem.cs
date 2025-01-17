using System;
using UnityEngine;

namespace RPG_Template
{
    public class ExperienceSystem: BasePointSystem
    {
        public int currentLevel {  get; private set; }
        public int maxLevel { get; private set; } = 100;
        public bool canLevelUp { get; private set; }

        public ExperienceSystem(int currentLevel, int maxLevel)
        {
            this.currentLevel = currentLevel;
            this.maxLevel = maxLevel;
            this.canLevelUp = true;
        }

        public ExperienceSystem(int currentLevel)
        {
            this.currentLevel = currentLevel;
            this.canLevelUp = true;
        }

        // Method used to give exp to this instance
        public void PlusExperience(int exp)
        {
            // If it's already in max level, there's no need to get experience
            if (!canLevelUp)
            {
                return;
            }

            // This loop is used in case the instance gets exp enough to level up multiple times
            while (currentPoints + exp > maxPoints)
            {
                if (currentLevel == maxLevel)
                {
                    BlockExpGain();
                    return;
                }

                exp -= (int)(maxPoints - currentPoints);
                LevelUp();
            }
        }

        public void LevelUp()
        {
            currentLevel++;
            ChangeCurrentPoints(0);
            ChangeMaxPoints((float)Math.Pow(currentLevel, 4));      // You are free to change this formula as you desire, this is just an example
        }



        public void BlockExpGain()
        {
            canLevelUp = false;
        }

        public void UnblockExpGain()
        {
            canLevelUp = true;
        }
    }

}