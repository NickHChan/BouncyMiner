using System;
using TMPro;
using UnityEngine;
using Random = System.Random;
using Vector2 = System.Numerics.Vector2;

public class MenuBunny : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 5f;
    [SerializeField] private float forceAmount = 100f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _rb.AddTorque(torqueAmount);
        int randomNum = UnityEngine.Random.Range(0, 4);
        Debug.Log(randomNum);
        addRandomForce(randomNum, _rb);
    }

    private void addRandomForce(int ranNum, Rigidbody2D rb)
    {
        switch(ranNum)
        {
            case 0:
                rb.AddForce(UnityEngine.Vector2.up * forceAmount);
                break;
            case 1:
                rb.AddForce(UnityEngine.Vector2.right * forceAmount);
                break;
            case 2:
                rb.AddForce(UnityEngine.Vector2.down * forceAmount);
                break;
            case 3:
                rb.AddForce(UnityEngine.Vector2.left * forceAmount);
                break;
        };
    }
}
