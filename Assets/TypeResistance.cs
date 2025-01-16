using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace RPG_Template
{
    public class TypeResistance
    {
        public DamageTypes type { get; private set; }
        public float value { get; private set; }
        public float baseValue { get; private set; }

        private Dictionary<EventHandler<HandlerInfoArgs>, float> temporaryChanges;
        private Dictionary<EventHandler<HandlerInfoArgs>, float> temporaryMultiplierChanges;

        public TypeResistance(DamageTypes type, float value)
        {
            this.type = type;
            this.value = value;
            baseValue = value;
        }

        // TemporaryChange is used to link a resistance change to an event. For example, an equipment could have an event called "OnUnequip". The resistance change would be connected to the equipment, in a way that, OnUnequip could simply be called and all resistances would go back to normal.
        public void TemporaryChange(float value, EventHandler<HandlerInfoArgs> timeToReturn)
        {
            timeToReturn += TurnChangeOff;      // Subscribe to event

            temporaryChanges.Add(timeToReturn, value);      // Add entry on dictionary

            CalculateValue();
        }

        public void TurnChangeOff(object sender, HandlerInfoArgs e)
        {
            e.eventHandler -= TurnChangeOff;    // Unsubscribe from event

            temporaryChanges.Remove(e.eventHandler);    // remove entry from dictionary

            CalculateValue();
        }




        public void TemporaryMultiplierChange(float value, EventHandler<HandlerInfoArgs> timeToReturn)
        {
            timeToReturn += TurnMultiplierChangeOff;      // Subscribe to event

            temporaryMultiplierChanges.Add(timeToReturn, value);      // Add entry on dictionary

            CalculateValue();
        }

        public void TurnMultiplierChangeOff(object sender, HandlerInfoArgs e)
        {
            e.eventHandler -= TurnMultiplierChangeOff;    // Unsubscribe from event

            temporaryMultiplierChanges.Remove(e.eventHandler);    // remove entry from dictionary

            CalculateValue();
        }

        public void CalculateValue()
        {
            value = (baseValue + temporaryChanges.Values.Sum()) * temporaryMultiplierChanges.Values.Sum();
        }

    }

}