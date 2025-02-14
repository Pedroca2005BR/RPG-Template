using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace RPG_Template
{
    public class Stat
    {
        public Stats name { get; private set; }
        public float value { get; private set; }
        public float baseValue { get; private set; }

        private Dictionary<EventHandler<HandlerInfoArgs>, float> temporaryChanges;
        private Dictionary<EventHandler<HandlerInfoArgs>, float> temporaryMultiplierChanges;

        public Stat(Stats name, float value)
        {
            this.name = name;
            this.baseValue = value;
            CalculateValue();
        }

        // PermanentChange is used for almost every change in stats
        public void PermanentChange(float value)
        {
            this.baseValue += value;
            CalculateValue();
        }
        public void PermanentChangeMultiplier(float percent)
        {
            this.baseValue *= percent;
            CalculateValue();
        }



        // TemporaryChange and TemporaryMultiplierChange are used to link a stat change to an event. For example, an equipment could have an event called "OnUnequip". The stat change would be connected to the equipment, in a way that, OnUnequip could simply be called and all stats would go back to normal.
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