using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    [SerializeField] List<Toggle> toggles = new List<Toggle>();
    [SerializeField] bool[] locks;
    public enum Type {
        KEY,
        TOGGLE
    }
    public Type type;

    private void Awake() {
        locks = new bool[toggles.Count];
    }
    void Open() {
        Destroy(transform.parent.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out PlayerEntity playerEntity)) {
            if (playerEntity.TryOpenGate(this) && type == Type.KEY) {
                Open();
            }
        }
    }

    private void VerifyLock() {
        if (type != Type.TOGGLE) return;
        bool isOpen = true;
        for (int i = 0; i < locks.Length; i++) {
            if (!locks[i]) {
                isOpen = false;
            }
        }
        if (isOpen) {
            Open();
        }
    }

    public void OpenLock(Toggle toggle) {
        Debug.Log("0");
        if (type != Type.TOGGLE) return;
        Debug.Log("1");
        locks[toggles.IndexOf(toggle)] = true;
        VerifyLock();

    }
    public void CloseLock(Toggle toggle) {
        if (type != Type.TOGGLE) return;
        locks[toggles.IndexOf(toggle)] = false;
    }
}
