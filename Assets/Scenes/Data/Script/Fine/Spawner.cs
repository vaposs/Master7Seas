using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPrefab[] _prefab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _delay;
    [SerializeField] private Drop _drop;
    [SerializeField] private float _radiysSpawn;

    private WaitForSeconds _wait;
    private SpawnPrefab _tempObj;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);

        StartCoroutine(Spawners());
    }

    private IEnumerator Spawners()
    {
        while (true)
        {
            _tempObj = Instantiate(_prefab[Random.Range(0, _prefab.Length)], transform.position, Quaternion.identity);
            
            if (_tempObj.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDrop(_drop);
            }

            _tempObj.transform.position = Random.insideUnitCircle * _radiysSpawn;

            
            yield return _wait;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _radiysSpawn);
    }
}
