using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    System.Action<Target, GameObject> _onHit;

    public void Fire(float speed, System.Action<Target, GameObject> onHit)
    {
        _onHit = onHit;
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}
