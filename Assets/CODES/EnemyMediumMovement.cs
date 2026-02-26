using UnityEngine;

public class EnemyMediumMovement : MonoBehaviour
{
    [Header("Base Movement")]
    public float downSpeed = 2f;
    public float sideSpeed = 2f;
    public float sideAmount = 2f;

    [Header("Randomness (Individuality)")]
    public float randomDown = 0.3f;     // +/- variation
    public float randomSideSpeed = 0.5f;
    public float randomSideAmount = 0.5f;

    private Vector3 startPos;
    private float phase; // unique per enemy

    void Start()
    {
        startPos = transform.position;

        // unique phase so they don't sync
        phase = Random.Range(0f, Mathf.PI * 2f);

        // small per-enemy variation so they feel different
        downSpeed += Random.Range(-randomDown, randomDown);
        sideSpeed += Random.Range(-randomSideSpeed, randomSideSpeed);
        sideAmount += Random.Range(-randomSideAmount, randomSideAmount);
    }

    void Update()
    {
        float xOffset = Mathf.Sin((Time.time * sideSpeed) + phase) * sideAmount;

        transform.position += Vector3.down * downSpeed * Time.deltaTime;
        transform.position = new Vector3(startPos.x + xOffset, transform.position.y, transform.position.z);
    }
}