using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    [SerializeField] Health _health;
    public Health Health => _health;
}
