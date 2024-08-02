using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public static class TileIDCounter
{
    private static HashSet<int> counterList = new HashSet<int>();

    public static void resetCount()
    {
        counterList.Clear();
    }

    public static bool addID(int id)
    {
        return counterList.Add(id);
    }

    public static void deleteID(int id)
    {
        counterList.Remove(id);
    }
}
