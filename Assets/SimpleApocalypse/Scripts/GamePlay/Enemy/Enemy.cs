using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct EnemyInfo
{
    public string Id;
    public int Type;
    public int Health;
    public int Speed;
    public int Damage;
    public string ResourcePath;
    public string[] PrefabName;
}

[System.Serializable]
public class EnemyData
{
    public List<EnemyInfo> Data;
}

public interface IEnemyLogic
{
    void Attack(int Damage);
    Transform FindPlayer();
}

public abstract class Enemy
{
    public string Id { get; protected set; }
    public EnemyType EnemyType { get; protected set; }
    public EnemyView EnemyView { get; protected set; }
    public abstract void ChasingPlayer();
    public abstract void Attack();
    public abstract void TakeDamage(int damage, System.Action onDead);
    protected NavMeshAgent _navMeshAgent;
    protected IEnemyLogic _enemyLogic;
    protected int _health;
    protected int _speed;
    protected int _damage;

    public Enemy(EnemyInfo info, EnemyView enemyView, IEnemyLogic enemyLogic)
    {
        EnemyView = enemyView;
        _enemyLogic = enemyLogic;

        _health = info.Health;
        _speed = info.Speed;
        _damage = info.Damage;
    }
}
