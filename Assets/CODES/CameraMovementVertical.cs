using UnityEngine;
public class CameraFollowVertical : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool allowScroll = true;

    void LateUpdate()
    {
        if (!allowScroll) return;     // <-- ADD THIS LINE HERE (top of LateUpdate)
        transform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);
    }
}