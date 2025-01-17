using UnityEngine;
using System.Collections.Generic;

namespace RPG_Template
{
    public class Entity : MonoBehaviour
    {
        [Header("Entity Model")]
        [SerializeField] private EntityModel model;

        new string name;
        List<Stat> statList;
        List<PassiveSkill> passiveSkills;
        List<ActiveSkill> activeSkills;

        [Header("Health System")]
        [SerializeField] private float maxHealth;

        HealthSystem healthSystem;

        [Header("Experience System")]
        [SerializeField] private int currentLevel;

        ExperienceSystem experienceSystem;

        public void Setup()
        {
            healthSystem = new HealthSystem(maxHealth);
            experienceSystem = new ExperienceSystem(currentLevel);

            // Use the stat values on the model to make the stats in the entity
            // You may use any formula to make the stats work with the level
            for(int i = 0; i < model.values.Count; i++)
            {
                Stats name = (Stats)i;
                Stat stat = new Stat(name, model.values[i]);
                statList.Add(stat);
            }
        }
    }
}
