using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseBlockScript : MonoBehaviour
{
    private int _blockHealth = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Ore") && other.gameObject.CompareTag("Player"))
        {
            _blockHealth--;
        }
    }

    private void Update()
    {
        if (_blockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
