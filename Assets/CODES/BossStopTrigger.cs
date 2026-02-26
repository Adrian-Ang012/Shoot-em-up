using UnityEngine;

public class BossStopTrigger : MonoBehaviour
{
    [Header("Drag the OBJECT that has CameraFollowVertical on it")]
    public CameraFollowVertical cameraScrollScript;

    [Header("Drag your EnemySpawner OBJECT here (the one with EnemySpawner script)")]
    public EnemySpawner enemySpawnerScript;

    [Header("Boss stuff")]
    public GameObject bossRoot;               // optional: BossTank root object
    public MonoBehaviour[] turretScripts;     // drag your 3 Tower(Boss Shoot) scripts here

    private bool done = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (done) return;
        if (!other.CompareTag("Player")) return;

        done = true;

        // stop camera
        if (cameraScrollScript != null)
            cameraScrollScript.allowScroll = false;

        // stop spawns
        if (enemySpawnerScript != null)
            enemySpawnerScript.enabled = false;

        // show boss root (if you disabled it)
        if (bossRoot != null)
            bossRoot.SetActive(true);

        // enable turrets
        if (turretScripts != null)
        {
            foreach (var t in turretScripts)
                if (t != null) t.enabled = true;
        }
    }
}
