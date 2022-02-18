using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBlock : MonoBehaviour
{
    [SerializeField] Shield _shield;
    [SerializeField] Health _health;

    public void Block() {
        _shield.Block();
        _health.IsShield = true;
    }

    public void UnBlock() {
        _shield.UnBlock();
        _health.IsShield = false;
    }
}
