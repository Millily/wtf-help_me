using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private Mover _mover;
    private Renderer _renderer;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _mover.Move(_speed, _direction);
    }

    public void Initialize(float speed, Vector3 moveDirection, Vector3 position, Color color)
    {
        _speed = speed;
        _direction = moveDirection;
        _renderer.material.color = color;
        transform.position = position;
    }
}
