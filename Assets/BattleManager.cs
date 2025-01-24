
using System.Collections.Generic;

using UnityEngine;

using System;
using RPG_Template;

namespace RPG_Template
{
    public class BattleManager : MonoBehaviour
    {
        

        List<Entity> entitiesEngaged;

        public void AttackMade(Entity attacker, List<Entity> targets, ActiveSkill skill)
        {
            // TO DO: Calculate Damage with stats

            try
            {
                // First, let's see who wants to interfere with the attacker
                List<PassiveSkill> passives = new List<PassiveSkill>();

                foreach (Entity entity in entitiesEngaged)
                {
                    passives.AddRange(entity.GetIntruders(attacker, GlobalEvents.Attacking));
                }




                // Second, let's calculate the first effects and the damage
                AttackInstance attack = new AttackInstance(skill);

                // Each passive skill has special effects with special needs for parameters
                foreach (PassiveSkill passiveSkill in passives)
                {
                    ActivateSpecialEffectsForAttack(passiveSkill, attack);
                }




                // Third, let's see who wants to interfere with the defender
                foreach (Entity target in targets)
                {
                    List<PassiveSkill> defenderPassives = new List<PassiveSkill>();

                    foreach (Entity entity in entitiesEngaged)
                    {
                        defenderPassives.AddRange(entity.GetIntruders(target, GlobalEvents.Defending));
                    }

                    // Since the targets can individually interfere with the attack, its best to make a copy of it
                    AttackInstance newAttack = new AttackInstance(attack);
                    foreach (PassiveSkill passiveSkill in defenderPassives)
                    {
                        ActivateSpecialEffectsForAttack(passiveSkill, newAttack);
                    }

                    // Attacks are then executed (finally)

                    // Let's apply the Entity effects on the targets as we go
                    foreach (PassiveSkill passiveSkill in defenderPassives)
                    {
                        ActivateSpecialEffectsForEntities(passiveSkill, target);
                    }
                }


                // Lastly, let's apply the Entity effects for the attacker as well
                foreach (PassiveSkill passiveSkill in passives)
                {
                    ActivateSpecialEffectsForEntities(passiveSkill, attacker);
                }
            }
            // Attack was negated 
            catch (NegateAttackException nax)
            {
                // In case of attack negated, nothing happens
            }

            

            
            
        }

        private void ActivateSpecialEffectsForAttack(PassiveSkill passiveSkill, AttackInstance attack)
        {
            foreach (SpecialEffect se in passiveSkill.specialEffects)
            {

                if (se.parameterNeeds == SpecialEffectNeeds.AttackInstance)
                {
                    se.ActivateEffect(attack);
                    break;
                }

            }
        }

        private void ActivateSpecialEffectsForEntities(PassiveSkill passiveSkill, Entity entity)
        {
            foreach (SpecialEffect se in passiveSkill.specialEffects)
            {
                if (se.parameterNeeds == SpecialEffectNeeds.Entity)
                {
                    if (passiveSkill.numberOfTargets == NumberOfTargets.One) se.ActivateEffect(entity);
                    else
                    {
                        for (int i = 0; i <= entitiesEngaged.Count; i++)
                        {
                            if (entitiesEngaged[i].side == entity.side)
                            {
                                se.ActivateEffect(entitiesEngaged[i]);
                            }
                        }
                    }
                    break;
                }
            }
        }

        private void ApplyAttack(AttackInstance attack, Entity target)
        {
            foreach (DamageTypes damageType in attack.damageTypes)
            {
                // TO DO: Calculate Damage with stats
            }
        }
    }
}
