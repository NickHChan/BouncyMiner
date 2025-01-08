using System;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            TurnOnStarPower();
        }
    }

    private void TurnOnStarPower()
    {
        FindAnyObjectByType<Player>().ChangePlayerIsVulnerable();
    }
}
