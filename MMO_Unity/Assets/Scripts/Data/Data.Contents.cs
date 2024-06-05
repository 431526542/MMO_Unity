using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Stat
[Serializable]//메모리에 들고있는 데이터를 파일로 변환해주는 기능
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}
[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDict()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();

        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);
        return dict;
    }
}
#endregion