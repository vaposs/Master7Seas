using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private Enemy[] _enemies;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log(_enemies.Length);
        }
    }
}
