using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RandomWithWeights
{
    public static class RandomWithWeight
    {
        public static T Lotto<T>(IEnumerable<WeightNode<T>> itemWeightPairs)
        {
            var sortedPairs = itemWeightPairs.OrderByDescending(x => x.Weight).ToArray();
            float total = sortedPairs.Select(x => x.Weight).Sum();
            float randomPoint = UnityEngine.Random.Range(0, total);
            foreach (var elem in sortedPairs)
            {
                if (randomPoint < elem.Weight)
                {
                    return elem.Node;
                }
                randomPoint -= elem.Weight;
            }
            return sortedPairs[sortedPairs.Length - 1].Node;
        }

        public static List<T> Lottos<T>(IEnumerable<WeightNode<T>> itemWeightPairs, int count) 
        {
            var results = new List<T>();
            for(int i = 0; i < count; i++)
            {
                results.Add(Lotto<T>(itemWeightPairs));
            }
            return results;
        }
    }
}