using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] Transform _bulletSample;
    [SerializeField] Transform _spawnBulletPos;
    ObjectPool<Transform> _poolBullet;

    private void Awake()
    {
        _poolBullet = new ObjectPool<Transform>(_bulletSample);
    }

    public Transform SpawnBullet()
    {
        var bullet = _poolBullet.Get();
        bullet.position = _spawnBulletPos.position;
        return bullet;
    }
}
