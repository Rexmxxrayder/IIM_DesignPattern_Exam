using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour {
    [SerializeField] BulletRecyclerReference _bulletRecyclerRef;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] bool _canFire = true;

    public bool CanFire { get { return _canFire; } set { _canFire = value; } }


    public void FireBullet(int power) {
        var b = _bulletRecyclerRef.Summon(_spawnPoint.transform.position,
            Quaternion.identity,
            _spawnPoint.TransformDirection(Vector3.right),
            power);
    }

}
