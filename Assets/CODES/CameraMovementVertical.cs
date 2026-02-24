using UnityEngine;

public class CameraFollowVertical : MonoBehaviour
{
    public float scrollSpeed = 2f; // constant upward speed

    void LateUpdate()
    {
        transform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);
    }
}