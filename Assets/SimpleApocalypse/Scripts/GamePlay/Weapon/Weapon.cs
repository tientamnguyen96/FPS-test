using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponInfo
{
    public string Id;
    public int Type;
    public int Magazine;
    public float FireRate;
    public float BulletSpeed;
    public float ReloadSpeed;
    public int Damage;
    public string ResourcePath;
}

public enum Target
{
    None = 0,
    Wall = 1,
    Head = 2,
    Body = 3
}

public abstract class Weapon
{
    public string Id { get; protected set; }
    public int Ammo { get; protected set; }
    public WeaponView WeaponView { get; protected set; }
    protected WeaponInfo _info;
    public abstract void Fire();
    public abstract void Reload();

    public Weapon(WeaponInfo info, WeaponView view)
    {
        WeaponView = view;
        _info = info;
    }
}
