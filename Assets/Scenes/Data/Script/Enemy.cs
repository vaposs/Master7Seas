using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpawnPrefab
{
    private Drop _drop;

    public int XP { get; private set; } = 5;


    public void Destroed()
    {
        _drop = Instantiate(_drop);
        _drop.transform.position = transform.position;
        Destroy(this.gameObject);
    }

    public void DestroeOnPlayer()
    {
        Destroy(this.gameObject);
    }

    public void TakeDrop(Drop drop)
    {
        _drop = drop;
    }
}
