
using System.Collections.Generic;

using UnityEngine;

using System;
using RPG_Template;
using static UnityEngine.GraphicsBuffer;
using System.Collections;

namespace RPG_Template
{
    public class BattleManager : MonoBehaviour
    {

        List<Entity> entitiesEngaged;

        public void AttackMade(Entity attacker, List<Entity> targets, ActiveSkill skill)
        {
            try
            {
                // First, let's see who wants to interfere with the attacker
                List<PassiveSkill> passives = new List<PassiveSkill>();

                foreach (Entity entity in entitiesEngaged)
                {
                    passives.AddRange(entity.GetIntruders(attacker, GlobalEvents.Attacking));
                }

                // Second, let's calculate the first effects
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

                    // The attack may also have an effect of their own that we must consider
                    foreach (SpecialEffect specialEffect in attack.specialEffects)
                    {
                        if (specialEffect.parameterNeeds == SpecialEffectNeeds.AttackInstance)
                        {
                            specialEffect.ActivateEffect(attack, null);
                        }
                    }

                    foreach (PassiveSkill passiveSkill in defenderPassives)
                    {
                        ActivateSpecialEffectsForAttack(passiveSkill, newAttack);
                    }

                    // Calculate Damage
                    float dmgMultiplier = ApplyResistances(newAttack, target);
                    float attackStat = GetRightStat(newAttack.statAttackerUsed, attacker);
                    float defendStat = GetRightStat(newAttack.statDefenderUsed, target);
                    newAttack.damage = CalculateDamageWithStat(newAttack.damage, attackStat, defendStat) * dmgMultiplier;

                    // Now that the damage was calculated, we just need to send the damage to the entity
                    if (attack.damage < 0)
                    {
                        target.healthSystem.Heal(attack.damage);
                    }
                    else
                    {
                        target.healthSystem.Damage(attack.damage);
                    }


                    // Let's apply the Entity effects on the targets as we go
                    foreach (PassiveSkill passiveSkill in defenderPassives)
                    {
                        ActivateSpecialEffectsForEntities(passiveSkill, target);
                    }

                    // The attack may also have an effect of their own that we must consider
                    foreach (SpecialEffect specialEffect in attack.specialEffects)
                    {
                        if (specialEffect.parameterNeeds == SpecialEffectNeeds.Target)
                        {
                            specialEffect.ActivateEffect(target, null);
                        }
                    }
                }


                // Lastly, let's apply the Entity effects for the attacker as well
                foreach (PassiveSkill passiveSkill in passives)
                {
                    ActivateSpecialEffectsForEntities(passiveSkill, attacker);
                }

                foreach (SpecialEffect specialEffect in attack.specialEffects)
                {
                    if (specialEffect.parameterNeeds == SpecialEffectNeeds.Attacker)
                    {
                        specialEffect.ActivateEffect(attacker, null);
                    }
                }
            }
            // Attack was negated 
            catch (NegateAttackException nax)
            {
                // In case of attack negated, nothing happens
                Debug.Log(nax.Message);
            }

            

            
            
        }

        private void ActivateSpecialEffectsForAttack(PassiveSkill passiveSkill, AttackInstance attack)
        {
            foreach (SpecialEffect se in passiveSkill.specialEffects)
            {

                if (se.parameterNeeds == SpecialEffectNeeds.AttackInstance)
                {
                    se.ActivateEffect(attack, null);
                }

            }
        }

        private void ActivateSpecialEffectsForEntities(PassiveSkill passiveSkill, Entity entity)
        {
            foreach (SpecialEffect se in passiveSkill.specialEffects)
            {
                if (se.parameterNeeds == SpecialEffectNeeds.Target || se.parameterNeeds == SpecialEffectNeeds.Attacker)
                {
                    // If the Skill has more than one target, we need to activate its effects to everyone in the team
                    if (passiveSkill.numberOfTargets == NumberOfTargets.One) se.ActivateEffect(entity, null);
                    else
                    {
                        for (int i = 0; i <= entitiesEngaged.Count; i++)
                        {
                            if (entitiesEngaged[i].side == entity.side)
                            {
                                se.ActivateEffect(entitiesEngaged[i], null);
                            }
                        }
                    }
                    break;
                }
            }
        }

        // Apply all necessary resistances to a multiplier and returns it
        private float ApplyResistances(AttackInstance attack, Entity target)
        {
            float dmgMultiplier = 1;
            foreach (DamageTypes damageType in attack.damageTypes)
            {
                // Get the resistances and add the multipliers
                for(int i = 0;i <= target.typeResistances.Count;i++)
                {
                    if (target.typeResistances[i].type == damageType)
                    {
                        dmgMultiplier -= target.typeResistances[i].value;
                        break;
                    }
                }
            }

            return dmgMultiplier;
        }

        // Returns the stat value needed
        private float GetRightStat(Stats statWanted, Entity entity)
        {
            for (int i = 0; i < entity.statList.Count; i++)
            {
                if (statWanted == entity.statList[i].name)
                {
                    return entity.statList[i].value;
                }
            }

            throw new Exception("Stat required not found on entity" + entity.name + "!!!");
        }

        // Here you can use your formulas. The default here will be very simple, and you may want to change it
        private float CalculateDamageWithStat(float damage, float attackStat, float defendStat)
        {
            damage *= attackStat / defendStat;

            return damage;
        }
    }
}
