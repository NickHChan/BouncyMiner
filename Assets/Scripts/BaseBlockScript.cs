using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
            int ranNum = Random.Range(0, 101);
            if (ChanceToCreatePowerUp(ranNum))
            {
                CreatePowerUp();
            }

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
    
    private bool ChanceToCreatePowerUp(int ranNum)
    {
        if (ranNum < 95)
        {
            return false;
        } 
        return true;
    }
}
