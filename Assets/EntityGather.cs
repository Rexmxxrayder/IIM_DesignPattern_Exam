using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGather : MonoBehaviour {
    [SerializeField] Entity _entity;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out ITakable takable)) {
            takable.Take(_entity);
        }
    }
}
