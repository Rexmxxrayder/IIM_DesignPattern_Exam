using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    [SerializeField] GameObject sprite;
    public void Block() {
        sprite.SetActive(true);
    }

    public void UnBlock() {
        sprite.SetActive(false);
    }
}
