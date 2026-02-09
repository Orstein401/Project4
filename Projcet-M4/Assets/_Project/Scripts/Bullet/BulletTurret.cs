using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    [Header("Parametres")]
    private float speed;
    private float damage;
    [SerializeField] private float lifeTime;

    [Header("Componets")]
    private Rigidbody rb;

    [Header("Direction")]
    private Vector3 directionBullet;
    

    private void Awake()
    {
        Destroy(gameObject,lifeTime);
        rb= GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + directionBullet * (speed * Time.fixedDeltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<LifeController>(out var player))
        {
            player.TakeDamage(damage);
          
        }
        Destroy(gameObject);
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public void SetDirectionRotationAndSpeed(Vector3 direction, float speedBullet)
    {
        if(direction.magnitude>1)direction.Normalize();
        directionBullet = direction;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(rotation);

        speed= speedBullet;
    }

}
