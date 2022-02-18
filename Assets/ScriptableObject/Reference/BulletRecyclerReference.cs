using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/BulletRecyclerReference")]
public class BulletRecyclerReference : Reference<BulletRecycler> {
    public Bullet Summon(Vector3 position, Quaternion quaternion, Vector3 direction, int power) => Instance?.Summon(position, quaternion, direction, power);
    public void Store(Bullet item) => Instance?.Store(item);
}
