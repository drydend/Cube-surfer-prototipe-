﻿using System.Collections.Generic;

public static class ListExtentions
{
    public static T GetRandomElement<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}
