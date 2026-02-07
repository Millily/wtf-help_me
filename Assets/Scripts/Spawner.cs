using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _speed;

    private ObjectPool<Enemy> _poolObjects;
    private int maxCount = 10;

    private Bounds _bounds;

    private int _delay = 2;
    private Coroutine _coroutine;

    private void Awake()
    {
        _bounds = new Bounds(transform.position, transform.localScale);

        _poolObjects = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            maxSize: maxCount
            );
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            GetEnemy();
            yield return wait;
        }
    }

    private void GetEnemy()
    {
        _poolObjects.Get();
    }

    private void ActionOnGet(Enemy enemy)
    {
        Vector3 position = GetRandomPosition();
        Vector3 direction = GetRandomDirection(position);

        Color color = Random.ColorHSV();

        enemy.Initialize(_speed, direction, position, color);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(_bounds.min.x, _bounds.max.x);
        float y = Mathf.Abs(_bounds.max.y - transform.position.y);
        float z = Random.Range(_bounds.min.z, _bounds.max.z);

        return new Vector3(x, y, z);
    }

    private Vector3 GetRandomDirection(Vector3 position)
    {
        List<Vector3> directions = new List<Vector3>() { Vector3.back, Vector3.forward, Vector3.right, Vector3.left};

        return directions[Random.Range(0, directions.Count)];
    }
}