using System;
using System.Collections.Generic;
using System.Linq;

namespace IFuzeHostage.SpinWheel.Utilities
{
    /// <summary>
    /// Randomize lists based on weights of its elements
    /// </summary>
    internal static class WeightedRandom
    {
        private static Random _random = new Random();

        public static T GetItem<T>(IEnumerable<WeightedItem<T>> items)
        {
            float totalWeight = items.Sum(i => i.Weight);
            float randomNumber = (float)_random.NextDouble() * totalWeight;
            float cumulativeWeight = 0;
        
            foreach (var item in items)
            {
                cumulativeWeight += item.Weight;
                if (randomNumber <= cumulativeWeight)
                {
                    return item.Item;
                }
            }

            return default;
        }
    }
}