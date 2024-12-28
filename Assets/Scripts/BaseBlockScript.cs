using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseBlockScript : MonoBehaviour
{
    [SerializeField] private int _blockHealth = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Ore") && other.gameObject.CompareTag("Player"))
        {
            _blockHealth--;
        }
    }

    private void Update()
    {
        CheckIfBlockIsAlive();
    }

    private void CheckIfBlockIsAlive()
    {
        if (_blockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetBlockHealth(int health)
    {
        _blockHealth += health;
    }
}
