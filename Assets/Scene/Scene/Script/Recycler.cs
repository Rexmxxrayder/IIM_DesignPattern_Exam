using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Recycler<T> : MonoBehaviour where T : MonoBehaviour {
    [SerializeField] protected List<T> recycleItems = new List<T>();
    [SerializeField] protected T _prefab;
    [SerializeField] protected float _timeBeforeDelete;
    [SerializeField] Coroutine lastUsed;

    public T Spawn() {
        if(lastUsed != null)
            StopCoroutine(lastUsed);
        lastUsed = StartCoroutine(NotUsed());
        if (recycleItems.Count > 0) {
            T items = recycleItems[0];
            recycleItems.RemoveAt(0);
            return items;
        } else {
           return null;
        }
    }

    public void Store(T item) {
        recycleItems.Add(item);
        item.gameObject.SetActive(false);
    }

    public IEnumerator NotUsed() {
        yield return new WaitForSeconds(_timeBeforeDelete);
        if (recycleItems.Count > 0) {
            recycleItems.RemoveAt(0);
        }
    }
}
