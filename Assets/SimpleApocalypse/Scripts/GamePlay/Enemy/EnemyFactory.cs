using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    None = 0,
    NormalZombie = 1,
    BossZombie = 2
}

public class EnemyFactory : MonoBehaviour
{
    IEnemyLogic _enemyLogic;

    public void SetEnemyLogic(IEnemyLogic enemyLogic)
    {
        _enemyLogic = enemyLogic;
    }

    public Enemy CreateEnemy(EnemyInfo info)
    {
        var type = (EnemyType)info.Type;
        var view = CreateEnemyObject(info.ResourcePath, info.PrefabName);

        Enemy enemy = null;

        switch (type)
        {
            case EnemyType.NormalZombie:
                enemy = new NormalZombie(info, view, _enemyLogic);
                break;

            case EnemyType.BossZombie:
                break;
        }

        return enemy;
    }

    EnemyView CreateEnemyObject(string path, string[] names, Transform parent = null)
    {
        if (parent == null)
            parent = transform;

        EnemyView view = Object.Instantiate(Resources.Load<GameObject>(path + "/" + names[Random.Range(0, names.Length)]), parent).GetComponent<EnemyView>();

        return view;
    }
}
