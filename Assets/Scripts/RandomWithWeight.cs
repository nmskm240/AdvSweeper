using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class RandomWithWeight
{
    public static T Lotto<T>(IEnumerable<T> itemWeightPairs) where T : IHaveRarity
    {
        var sortedPairs = itemWeightPairs.OrderByDescending(x => x.Rarity).ToArray();
        float total = sortedPairs.Select(x => x.Rarity).Sum();
        float randomPoint = UnityEngine.Random.Range(0, total);
        foreach (T elem in sortedPairs)
        {
            if (randomPoint < elem.Rarity)
            {
                return elem;
            }
            randomPoint -= elem.Rarity;
        }
        return sortedPairs[sortedPairs.Length - 1];
    }

}