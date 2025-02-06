using System;
using TMPro;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MenuBunny : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 5f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _rb.AddTorque(torqueAmount);
        _rb.AddForce(UnityEngine.Vector2.right * 100f);
    }
}
