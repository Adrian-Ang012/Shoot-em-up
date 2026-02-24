using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float autoUpSpeed = 2f;
    public Camera mainCamera;

    void Start()
    {
        // Auto-assign if not set in Inspector
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Continuous upward movement
        transform.Translate(Vector2.up * autoUpSpeed * Time.deltaTime);

        // Manual WASD input (supports diagonals)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 manualMove = new Vector2(moveX, moveY).normalized;
        transform.Translate(manualMove * moveSpeed * Time.deltaTime);

        // Clamp player inside camera view
        Vector3 pos = transform.position;
        Vector3 viewPos = mainCamera.WorldToViewportPoint(pos);


        // Clamp between 0 and 1 viewport space (slightly inset so player isn’t half off-screen)
        viewPos.x = Mathf.Clamp(viewPos.x, 0f, 1f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0f, 1f);

        transform.position = mainCamera.ViewportToWorldPoint(viewPos);
    }
}