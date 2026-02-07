using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move(_speed, _direction);
    }

    public void Initialize(float speed, Vector3 moveDirection, Vector3 position)
    {
        _speed = speed;
        _direction = moveDirection;
        transform.position = position;
    }
}
