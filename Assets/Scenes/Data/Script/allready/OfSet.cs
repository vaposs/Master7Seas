using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfSet : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    void Update()
    {
        transform.position = new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y, transform.position.z);
    }
}
