using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalZombie : Enemy
{
    public NormalZombie(EnemyInfo info, EnemyView enemyView, IEnemyLogic enemyLogic) : base(info, enemyView, enemyLogic)
    {
        _navMeshAgent = enemyView.GetComponent<NavMeshAgent>();
    }

    public override void ChasingPlayer()
    {
        _navMeshAgent.SetDestination(_enemyLogic.FindPlayer().position);
    }

    public override void Attack()
    {
        _enemyLogic.Attack(_damage);
    }

    public override void TakeDamage(int damage, System.Action onDead)
    {
        _health -= damage;

        if (_health <= 0)
            onDead?.Invoke();
    }
}
