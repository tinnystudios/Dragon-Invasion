using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomUtils
{
    public static T GetByProbability<T>(List<T> list)
        where T : class, IChance
    {
        if (list.Count == 1)
            return list[0];

        int totalWeight = list.Sum(t => t.Priority);

        var rnd = new System.Random();
        int randomNumber = rnd.Next(0, totalWeight);

        var type = list[0];

        foreach (var item in list)
        {
            if (randomNumber < item.Priority)
            {
                type = item;
                break;
            }
            randomNumber -= item.Priority;
        }
        return type;
    }
}