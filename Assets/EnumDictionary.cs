using System.Collections.Generic;
using System;
using UnityEngine;


namespace RPG_Template
{
    public class EnumDictionary<TEnum> where TEnum : Enum
    {
        private readonly Dictionary<TEnum, float> _dictionary;

        public EnumDictionary()
        {
            Array enums = Enum.GetValues(typeof(TEnum));

            _dictionary = new Dictionary<TEnum, float>();

            for (int i = 0; i < enums.Length; i++)
            {
                _dictionary[(TEnum)enums.GetValue(i)] = 0;
            }
        }

        public EnumDictionary(Array values)
        {
            Array enums = Enum.GetValues(typeof(TEnum));

            _dictionary = new Dictionary<TEnum, float>();

            for (int i = 0; i < values.Length; i++)
            {
                _dictionary[(TEnum)enums.GetValue(i)] = (float)values.GetValue(i);
            }
        }

        public EnumDictionary(EnumDictionary<TEnum> a)
        {
            _dictionary = a._dictionary;
        }


        public float this[TEnum key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        public void Add( EnumDictionary<TEnum> b)
        {

            foreach (TEnum key in _dictionary.Keys)
            {
                _dictionary[key] += b[key];
            }
        }
    }
}

