using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 8f;
    public Vector2 dir = Vector2.down;

    public void SetDirection(Vector2 newDir, float newSpeed)
    {
        dir = newDir.normalized;
        speed = newSpeed;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}