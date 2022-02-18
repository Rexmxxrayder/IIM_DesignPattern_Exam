using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRecycler : Recycler<Bullet> {
    public Bullet Summon(Vector3 position, Quaternion quaternion, Vector3 direction, int power) {
        Bullet bullet = Spawn();
        if (bullet == null) {
            bullet = Instantiate(_prefab, position, quaternion);
        }
        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = quaternion;
        bullet.Init(direction, power);
        return bullet;
    }
}
