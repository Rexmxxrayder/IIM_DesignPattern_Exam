using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    [SerializeField] Potion _prefab;
    public void Touch(int power)
    {
        int random = Random.Range(0, 3);
        if (random == 0) Instantiate(_prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
