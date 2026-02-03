using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Non è una interFace visto che ho deciso che solo il player abbia la vita
public class LifeController:MonoBehaviour 
{
    [SerializeField] private float hp = 200;
    [SerializeField] private float maxHp = 200;
    [SerializeField] UnityEvent<float, float> healthBar;
    [SerializeField] UnityEvent deathUi;

    private void Start()
    {
        hp = maxHp;
        healthBar.Invoke(hp, maxHp);
    }

    public void TakeDamage( float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DiePlayer();
        }
        healthBar.Invoke(hp, maxHp);
    }

    public void DiePlayer()
    {     
        deathUi.Invoke();
        Destroy(gameObject);
    }
}
