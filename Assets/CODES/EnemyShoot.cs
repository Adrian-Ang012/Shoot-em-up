using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject redBulletPrefab;
    [SerializeField] private Animator animator;

    [SerializeField] private float fireInterval = 1.0f;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireInterval;

        if (animator != null) animator.SetTrigger("shoot");

        Instantiate(redBulletPrefab, firePoint.position, firePoint.rotation);
    }
}