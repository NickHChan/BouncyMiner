using System;
using PlayerStatus;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static PlayerModes PlayerMode;
    private static int PlayerHealth = 3;
    private static float PlayerScore;
    [SerializeField] private Transform playerHealth;
    private SpriteRenderer PlayerSprite;

    [SerializeField] private float TorqueAmount = 3f;

    private Rigidbody2D rb;
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     PlayerMode = PlayerModes.Mining;
     PlayerSprite = GetComponentInChildren<SpriteRenderer>();
     PlayerSprite.color = Color.blue;
     Debug.Log("To Changes Modes use 1:Mining 2: Attacking 3: Defending");
    }
    
    void Update()
    {
        ChangePlayerMode();
        Debug.Log(PlayerMode);
    }
    
    //TODO: Add Attack Dmg(for Mining and Attack) and HP(for Attack and Defend)
    private void ChangePlayerMode()
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerMode = PlayerModes.Mining;
            PlayerSprite.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Tools.Sword.Durability > 0)
        {
            PlayerMode = PlayerModes.Attacking;
            PlayerSprite.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Tools.Shield.Durability > 0)
        {
            PlayerMode = PlayerModes.Defending;
            PlayerSprite.color = Color.green;
        }
    }

    //TODO: rest of logic like Defending an Ore doesn't lose health.
    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.AddTorque(TorqueAmount);
        if (other.gameObject.CompareTag("Ore") && PlayerMode == PlayerModes.Mining)
        {
            Destroy(other.gameObject); 
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Ore") && PlayerMode == PlayerModes.Attacking)
        {
            Tools.ReduceToolDurability(Tools.Sword);
        }
        else if (other.gameObject.CompareTag("Ore") && PlayerMode == PlayerModes.Defending)
        {
            Tools.ReduceToolDurability(Tools.Shield);
        }
        else if (other.gameObject.CompareTag("Enemy") && PlayerMode == PlayerModes.Attacking)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Enemy") && PlayerMode == PlayerModes.Defending)
        {
            Tools.ReduceToolDurability(Tools.Shield);
        }
        else if (other.gameObject.CompareTag("Trap") && PlayerMode == PlayerModes.Defending)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else if(other.gameObject.CompareTag("Enemy") && PlayerMode == PlayerModes.Mining || 
                other.gameObject.CompareTag("Trap") && PlayerMode == PlayerModes.Mining ||
                other.gameObject.CompareTag("Trap") && PlayerMode == PlayerModes.Attacking)
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
    public static void ResetPlayerHealth()
    {
        PlayerHealth = 3;
    }
    
    
    private void DestroyAHeart()
    {
        Destroy(playerHealth.GetChild(0).gameObject);
    }



}
