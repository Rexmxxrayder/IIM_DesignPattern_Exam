using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceSetter : MonoBehaviour
{
    [SerializeField] PlayerEntity _entity;
    [SerializeField] PlayerReference _playerRef;

    void Awake()
    {
        (_playerRef as IReferenceSetter<PlayerEntity>).SetInstance(_entity);
       
    }
}
