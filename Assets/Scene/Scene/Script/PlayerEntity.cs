using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity {
    int _keys = 0;
    public int Keys { get => _keys; private set => _keys = value; }
    public void AddKeys(int amount) {
        if (amount <= 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");
        _keys += amount;
    }

    public void RemoveKeys(int amount) {
        if (amount <= 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");
        if (amount > _keys) throw new ArgumentException($"Argument amount {nameof(amount)} is too high");
        _keys -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<ITakable>(out ITakable takable)) {
            takable.Take(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<ITakable>(out ITakable takable)) {
            takable.Take(this);
        }
    }

    public bool TryOpenGate(Gate gate) {
        if (gate == null) throw new ArgumentNullException(nameof(gate));
        if (Keys > 0) {
            RemoveKeys(1);
            return true;
        }
        return false;
    }
}


