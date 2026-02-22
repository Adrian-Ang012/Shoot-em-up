using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject blueBulletPrefab;
    [SerializeField] private Animator animator;

    [Header("Tuning")]
    [SerializeField] private float fireCooldown = 0.15f;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time < nextFireTime) return;

        if (Input.GetMouseButton(0))
        {
            nextFireTime = Time.time + fireCooldown;

            if (animator != null) animator.SetTrigger("shoot");

            Instantiate(blueBulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}