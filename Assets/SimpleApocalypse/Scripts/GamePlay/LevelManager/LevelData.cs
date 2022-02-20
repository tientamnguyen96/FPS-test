using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Level
{
    public string Id;
    public int EnemyNumber;
    public float SpawnRate;
    public string[] EnemyUses;
}

[System.Serializable]
public class LevelData
{
    public string Id;
    List<Level> Data;
}
