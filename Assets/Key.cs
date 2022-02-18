using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ITakable {
    public void Take(Entity taker) {
        if (taker.TryGetComponent(out PlayerEntity playerEntity)) {
            playerEntity.AddKeys(1);
            Destroy(gameObject);
        }
    }
}
