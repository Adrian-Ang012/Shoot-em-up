using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float autoUpSpeed = 2f;
    public Camera mainCamera;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY);
        if (moveInput.magnitude > 1f) moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        Vector2 autoMove = Vector2.up * autoUpSpeed;
        Vector2 manualMove = moveInput * moveSpeed;

        rb.linearVelocity = autoMove + manualMove;

        ClampToCamera();
    }

    void ClampToCamera()
    {
        Vector3 pos = transform.position;
        Vector3 viewPos = mainCamera.WorldToViewportPoint(pos);

        viewPos.x = Mathf.Clamp(viewPos.x, 0f, 1f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0f, 1f);

        Vector3 clampedWorld = mainCamera.ViewportToWorldPoint(viewPos);
        clampedWorld.z = transform.position.z;

        rb.position = clampedWorld;
    }
}