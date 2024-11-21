using System.Collections.Generic;
using RPG.Inventories;
using RPG.Stats;
using UnityEngine;

namespace RPG.Inventories
{
    public class StatsEquipment : Equipment, IModifierProvider
    {
        public IEnumerable<float> GetAdditiveModifier(Stats.Stats stat)
        {
            return null;
            foreach (var slot in GetAllPopulatedSlots())
            {
                //
            }
        }

        public IEnumerable<float> GetPercentageModifier(Stats.Stats stat)
        {
            throw new System.NotImplementedException();
        }
    }

}