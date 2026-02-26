using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    public float enterSpeed = 2.0f;

    public bool IsMoving { get; private set; }

    float targetStopY;

    public void BeginEntrance(float stopY)
    {
        targetStopY = stopY;
        IsMoving = true;
    }

    void Update()
    {
        if (!IsMoving) return;

        Vector3 p = transform.position;
        p.y = Mathf.MoveTowards(p.y, targetStopY, enterSpeed * Time.deltaTime);
        transform.position = p;

        if (Mathf.Abs(transform.position.y - targetStopY) < 0.01f)
            IsMoving = false;
    }
}