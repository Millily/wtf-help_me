using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(float speed, Vector3 direction)
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}