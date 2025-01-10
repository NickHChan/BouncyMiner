using System;
using PlayerStatus;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static PlayerModes _playerMode;
    private static int _playerHealth = 3;
    private static float _playerScore;
    [SerializeField] private Transform playerHealth;
    private SpriteRenderer _playerSprite;
    public static bool PlayerBrokeATool;
    private static bool _playerIsVulnerable = true;
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private Sprite swordImage;
    [SerializeField] private float torqueAmount = 3f;
    

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    void Start()
    {
     _rb = GetComponent<Rigidbody2D>();
     _playerMode = PlayerModes.Mining;
     _playerSprite = GetComponentInChildren<SpriteRenderer>();
     _playerSprite.color = Color.blue;
     _sprite = GetComponentInChildren<SpriteRenderer>();
     Debug.Log("To Changes Modes use 1:Mining 2: Attacking 3: Defending");
    }
    
    void Update()
    {
        ChangePlayerMode();
        CheckPlayerBrokeTool();
        //CheckIfPlayerIsDead();
    }
    
    private void ChangePlayerMode()
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerMode = PlayerModes.Mining;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Tools.Sword["Durability"] > 0)
        {
            _playerMode = PlayerModes.Attacking;
            _sprite.sprite = swordImage;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Tools.Shield["Durability"] > 0)
        {
            _playerMode = PlayerModes.Defending;
            _playerSprite.color = Color.green;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        _rb.AddTorque(torqueAmount);
        if (!_playerIsVulnerable && other.gameObject.CompareTag("Ore") ||
            !_playerIsVulnerable && other.gameObject.CompareTag("Enemy") ||
            !_playerIsVulnerable && other.gameObject.CompareTag("Trap"))
        {
            Destroy(other.gameObject);
            PlayerGainsScore(500);
            return;
        }

        if (other.gameObject.CompareTag("Ore") && _playerMode == PlayerModes.Mining)
        {
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Ore") && _playerMode == PlayerModes.Attacking)
        {
            Tools.ReduceToolDurability(Tools.Sword);
        }
        else if (other.gameObject.CompareTag("Ore") && _playerMode == PlayerModes.Defending)
        {
            Tools.ReduceToolDurability(Tools.Shield);
        }
        else if (other.gameObject.CompareTag("Enemy") && _playerMode == PlayerModes.Attacking)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else if (other.gameObject.CompareTag("Enemy") && _playerMode == PlayerModes.Defending)
        {
            Tools.ReduceToolDurability(Tools.Shield);
        }
        else if (other.gameObject.CompareTag("Trap") && _playerMode == PlayerModes.Defending)
        {
            Destroy(other.gameObject);
            PlayerGainsScore(100);
        }
        else if(other.gameObject.CompareTag("Enemy") && _playerMode == PlayerModes.Mining || 
                other.gameObject.CompareTag("Trap") && _playerMode == PlayerModes.Mining ||
                other.gameObject.CompareTag("Trap") && _playerMode == PlayerModes.Attacking)
        {
            PlayerTakesDamage();
            if (_playerHealth >= 0)
            {
                DestroyAHeart();
            }

        }
    }
    

    private static void PlayerTakesDamage()
    {
        if (_playerHealth > 0)
        {
            _playerHealth--;
        }
    }

    private void CheckIfPlayerIsDead()
    {
        if (_playerHealth <= 0)
        {
            Time.timeScale = 0;
            gameoverScreen.SetActive(true);
        }
    }

    public static void PlayerGainsHealth()
    {
        _playerHealth++;
    }

    public static void PlayerGainsScore(float score)
    {
        _playerScore += score;
    }

    public static float PlayerScoreValue()
    {
        return _playerScore;
    }

    public static void ResetPlayerScore()
    {
        _playerScore = 0;
    }
    public static void ResetPlayerHealth()
    {
        _playerHealth = 3;
    }

    private void DestroyAHeart()
    {
        Destroy(playerHealth.GetChild(0).gameObject);
    }

    public void CheckPlayerBrokeTool()
    {
        if (PlayerBrokeATool)
        {
            _playerMode = PlayerModes.Mining;
            _playerSprite.color = Color.blue;
        }

        PlayerBrokeATool = false;

    }

    public static void ChangePlayerIsVulnerable(bool isVulnerable)
    {
        _playerIsVulnerable = isVulnerable;
    }




}
