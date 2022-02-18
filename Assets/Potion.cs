using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, ITakable {
    [SerializeField] int _healValue;
    public void Take(Entity taker) {
        taker.Health.Heal(_healValue);
        Destroy(gameObject);
    }
}
