using UnityEngine;

public class EnemySmallMovement : MonoBehaviour
{
    public float speed = 2.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (rb != null)
            rb.linearVelocity = Vector2.down * speed;
    }
}