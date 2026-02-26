using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public float extraBelow = 5f;
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (cam == null) return;

        float bottomY = cam.transform.position.y - cam.orthographicSize;
        if (transform.position.y < bottomY - extraBelow)
        {
            Destroy(gameObject);
        }
    }
}