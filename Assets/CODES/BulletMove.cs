using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeSeconds = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeSeconds);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}