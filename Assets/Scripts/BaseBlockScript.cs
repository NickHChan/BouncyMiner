using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseBlockScript : MonoBehaviour
{
    [SerializeField] private int _blockHealth = 1;
    [SerializeField] private GameObject powerUpPrefab;

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
            CreatePowerUp();
        }
    }

    public void AddBlockHealth(int health)
    {
        _blockHealth += health;
    }

    private void CreatePowerUp()
    {
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
    }
}
