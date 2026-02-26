using UnityEngine;

public class EnemyMoveDown : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }
}