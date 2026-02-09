using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDeath : MonoBehaviour
{
  [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<LifeController>(out var player))
        {
            player.TakeDamage(damage);
        }
    }
}
