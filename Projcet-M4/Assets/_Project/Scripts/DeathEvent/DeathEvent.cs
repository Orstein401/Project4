using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<LifeController>(out var player))
        {
            player.DiePlayer();
        }
        else
        {
            Destroy(collision.gameObject);
        }
      
    }
}
