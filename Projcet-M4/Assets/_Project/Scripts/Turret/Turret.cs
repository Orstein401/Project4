using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Transform of reference")]
    [SerializeField] private GameObject player; //Inizialmente passavo il transform ma questo faceva problemi, qunado sono diventati prefab
    [SerializeField] private Transform firePoint;

    [Header("Parametres turret")]
    [SerializeField] private float range;
    [SerializeField] private float speedRotation;
    [SerializeField] private float fireRate;
    private float lastTimeShoot;

    [Header("Projectile data")]
    [SerializeField] private BulletTurret bulletPrefab;
    private Vector3 direction;

    [Header("Parametres Projectile")]
    [SerializeField] private float speedProjectile;
    [SerializeField] private float damageProjectile;

    
    private void Update()
    {
        if (player != null)
        {
            direction = player.transform.position - transform.position;
            if (direction.magnitude <= range)
            {
                RotateTurret();
                if (Time.time - lastTimeShoot > fireRate)
                {
                    Shoot(direction);
                    lastTimeShoot = Time.time;
                }
            }
        }

    }

    private void Shoot(Vector3 direction)
    {
        BulletTurret bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;
        bullet.SetDamage(damageProjectile);
        bullet.SetDirectionRotationAndSpeed(direction, speedProjectile);
    }

    private void RotateTurret()
    {
        direction.y = 0;
        direction.Normalize();
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.Lerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);

        transform.rotation = rotation;
    }


}
