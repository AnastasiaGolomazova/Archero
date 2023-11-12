using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _maxEnemy;

    [SerializeField] private float _spawnDelay;

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<Transform> spawns = new();

    private GameObject _parent;

    private int currentCountEnemy;

    private void Start()
    {
        _parent = new();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if(currentCountEnemy <= _maxEnemy)
            {
                Transform positionOfSpawn = spawns[Random.Range(0, spawns.Count)];

                Instantiate(enemy, positionOfSpawn.position, Quaternion.identity, _parent.transform);
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
