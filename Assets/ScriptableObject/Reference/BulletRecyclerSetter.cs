using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRecyclerSetter : MonoBehaviour {
    [SerializeField] BulletRecycler _bulletRecycler;
    [SerializeField] BulletRecyclerReference _bulletRecyclerRef;

    void Awake() {
        (_bulletRecyclerRef as IReferenceSetter<BulletRecycler>).SetInstance(_bulletRecycler);
    }
}
