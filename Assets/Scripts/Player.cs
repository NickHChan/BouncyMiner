using System;
using PlayerStatus;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static PlayerModes PlayerMode = PlayerModes.Mining;
    private static int PlayerHealth = 3;
    private static float PlayerScore = 0;

    [SerializeField] private float TorqueAmount = 3f;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
     Debug.Log("To Changes Modes use 1:Mining 2: Attacking 3: Defending");
    }

    // Update is called once per frame
    void Update()
    {
        ChangePlayerMode();
    }

	private void ChangePlayerMode()
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerMode = PlayerModes.Mining;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerMode = PlayerModes.Attacking;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerMode = PlayerModes.Defending;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.AddTorque(TorqueAmount);
        Debug.Log(other.gameObject.tag);
    }

    public static void PlayerTakesDamage()
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
}
