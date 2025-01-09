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

    //TODO set a timer for this to expire
    private void TurnOnStarPower()
    {
        Player.ChangePlayerIsVulnerable(false);
    }
}
