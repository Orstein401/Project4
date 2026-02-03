using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float amplitude;
    [SerializeField] UnityEvent<int> coinCount;
    [SerializeField] private int valueCoin;

    private void Update()
    {
       MoveCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out var player))
        {
            AddCoin();
            Destroy(gameObject);
        }
    }
    private void MoveCoin()
    {
        float angle= Time.time*speed;
        float move =transform.position.y- Mathf.Sin(angle) * amplitude* Time.deltaTime;

        transform.position = new Vector3(transform.position.x, move, transform.position.z);
    }

    private void AddCoin()
    {
        coinCount.Invoke(valueCoin);
    }
}
