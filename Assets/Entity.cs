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
		List<TypeResistance> typeResistances;

		[Header("Health System")]
		[SerializeField] private float maxHealth;

		HealthSystem healthSystem;

		[Header("Experience System")]
		[SerializeField] private int currentLevel;

		ExperienceSystem experienceSystem;


		// locked information
		public int side {  get; private set; }

		public void Setup()
		{
			healthSystem = new HealthSystem(maxHealth);
			experienceSystem = new ExperienceSystem(currentLevel);

			// Use the stat values on the model to make the stats in the entity
			// You may use any formula to make the stats work with the level
			for(int i = 0; i < model.statValues.Count; i++)
			{
				Stats name = (Stats)i;
				Stat stat = new Stat(name, model.statValues[i]);
				statList.Add(stat);
			}

			// Use the Resistance values on the model
            for (int i = 0; i < model.resistanceValues.Count; i++)
            {
                DamageTypes name = (DamageTypes)i;
                TypeResistance resistance = new TypeResistance(name, model.resistanceValues[i]);
                typeResistances.Add(resistance);
            }
        }

		

		public List<PassiveSkill> GetIntruders(Entity entity, GlobalEvents classification)
		{
			bool ally = false, yourself = false;
			List<PassiveSkill> intruders = new List<PassiveSkill>();

			if (side == entity.side)
			{
				if (entity == this)
				{
					yourself = true;
				}

				ally = true;
			}

			foreach (PassiveSkill skill in passiveSkills)
			{
				if (skill.triggers.Contains(classification))
				{
					switch (skill.possibleTargets)
					{
						case PossibleTargets.Caster:
							if (yourself) intruders.Add(skill);
							break;

						case PossibleTargets.AlliesExceptCaster:
							if (ally && !yourself) intruders.Add(skill);
							break;

						case PossibleTargets.Allies:
							if (ally) intruders.Add(skill);
							break;

						case PossibleTargets.Enemies:
							if (!ally) intruders.Add(skill);
							break;

						case PossibleTargets.Everyone:
							intruders.Add(skill);
							break;

						case PossibleTargets.EveryoneElse:
							if (!yourself) intruders.Add(skill);
							break;

						default:
							Debug.LogError(skill.name + " has not implemented target options!");
							break;
					}
				}
			}

			return intruders;
		}
	}
}
