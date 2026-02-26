using UnityEngine;

public class BossFightController : MonoBehaviour
{
    [Header("Trigger by CAMERA progress (drag Main Camera Transform here)")]
    public Transform camTransform;

    [Tooltip("When camera reaches this Y: stop spawning enemies")]
    public float stopSpawnerAtY = 120f;

    [Tooltip("When camera reaches this Y: stop camera + start boss fight")]
    public float startBossFightAtY = 135f;

    [Header("Stop systems first")]
    public CameraFollowVertical cameraScroll;   // drag the script component from MainCamera
    public EnemySpawner enemySpawner;           // drag your spawner object/script

    [Header("Boss in scene (already placed)")]
    public GameObject bossRoot;                 // drag BossTank (scene object) here

    [Header("Boss fight starts")]
    public BossHealth bossHealth;               // drag BossHealth from bossRoot (or auto-find)
    public MonoBehaviour[] turretsToEnable;     // drag the 3 Tower objects that have BossShoot (or the BossShoot components)

    bool stoppedSpawner;
    bool startedBoss;

    void Start()
    {
        // Boss exists already but should NOT fight yet
        if (bossRoot != null)
            bossRoot.SetActive(true); // keep it visible if you want; set false if you want it hidden

        // Make boss invulnerable before fight starts
        if (bossHealth == null && bossRoot != null) bossHealth = bossRoot.GetComponentInChildren<BossHealth>();
        if (bossHealth != null) bossHealth.SetInvulnerable(true);

        // Disable turrets before fight starts
        SetTurretsEnabled(false);
    }

    void Update()
    {
        if (camTransform == null) return;

        float camY = camTransform.position.y;

        // 1) Stop spawner at first Y
        if (!stoppedSpawner && camY >= stopSpawnerAtY)
        {
            stoppedSpawner = true;

            if (enemySpawner != null) enemySpawner.enabled = false;
        }

        // 2) Stop camera + start boss fight at later Y
        if (!startedBoss && camY >= startBossFightAtY)
        {
            startedBoss = true;

            if (cameraScroll != null) cameraScroll.allowScroll = false;

            // Start boss fight
            if (bossHealth != null) bossHealth.SetInvulnerable(false);
            SetTurretsEnabled(true);

            Debug.Log("Boss fight started!");
        }
    }

    void SetTurretsEnabled(bool enabled)
    {
        if (turretsToEnable == null) return;

        for (int i = 0; i < turretsToEnable.Length; i++)
        {
            if (turretsToEnable[i] != null)
                turretsToEnable[i].enabled = enabled;
        }
    }
}