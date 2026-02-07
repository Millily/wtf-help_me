using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    private Bounds _bounds;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bounds = new Bounds(transform.position, transform.localScale);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int delay = 2;
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Create();
        }

        yield return wait;
    }

    private void Create()
    {
        float minSpeed = 1.0f;
        float maxSpeed = 5.0f;
        float speed = Random.Range(minSpeed, maxSpeed);

        Enemy enemy = Instantiate(_prefab);
        enemy.Initialize(speed, Direction(), Position());
    }

    private Vector3 Position()
    {
        float x = Random.Range(_bounds.min.x, _bounds.max.x);
        float y = transform.position.y;
        float z = Random.Range(_bounds.min.z, _bounds.max.z);
        Vector3 position = new Vector3(x, y, z);
        return position;
    }

    private Vector3 Direction()
    {
        return new Vector3(Random.Range(-1, 1), transform.position.y, Random.Range(-1, 1)).normalized;
    }
}