using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> Items;

    public int Count(string item)
    {
        return Items.Count(x => x.Contains(item));
    }
}