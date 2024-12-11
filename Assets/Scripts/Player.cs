using System;
using PlayerStatus;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static PlayerModes PlayerMode = PlayerModes.Mining;
    private static int PlayerHealth = 3;
    private static float PlayerScore;
    [SerializeField] private Transform playerHealth;
    private SpriteRenderer PlayerSprite;

    [SerializeField] private float TorqueAmount = 3f;

    private Rigidbody2D rb;
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     PlayerSprite = GetComponentInChildren<SpriteRenderer>();
     PlayerSprite.color = Color.blue;
     Debug.Log("To Changes Modes use 1:Mining 2: Attacking 3: Defending");
    }
    
    void Update()
    {
        ChangePlayerMode();
    }

    private void ChangePlayerMode()
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerMode = PlayerModes.Mining;
            PlayerSprite.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerMode = PlayerModes.Attacking;
            PlayerSprite.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerMode = PlayerModes.Defending;
            PlayerSprite.color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.AddTorque(TorqueAmount);
        if (other.gameObject.CompareTag("Ore") && PlayerMode == PlayerModes.Mining)
        {
            Destroy(other.gameObject); 
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Enemy") && PlayerMode == PlayerModes.Attacking)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Trap") && PlayerMode == PlayerModes.Defending)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else
        {
            PlayerTakesDamage();
            if (PlayerHealth > 0)
            {
                DestroyAHeart();
            }

        }
    }

    private static void PlayerTakesDamage()
    {
        if (PlayerHealth > 0)
        {
            PlayerHealth--;
        }
    }

    public static void PlayerGainsHealth()
    {
        PlayerHealth++;
    }

    public static void PlayerGainsScore(float score)
    {
        PlayerScore += score;
    }

    public static float PlayerScoreValue()
    {
        return PlayerScore;
    }

    public static void ResetPlayerScore()
    {
        PlayerScore = 0;
    }
    
    
    private void DestroyAHeart()
    {
        Destroy(playerHealth.GetChild(0).gameObject);
    }



}
